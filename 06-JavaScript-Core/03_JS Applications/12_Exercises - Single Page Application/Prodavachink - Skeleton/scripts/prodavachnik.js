function startApp() {

    const appKey = 'kid_rkrkInDy4'; // 'kid_BJcZftNP-'
    const appSecret = '48579b0828524a52b34474ea3212418d'; // '55297dee18e3431aa460d74048b4bdf5'
    const baseUrl = 'https://baas.kinvey.com/';

    const templates = {};

    loadTemplates();

    async function loadTemplates() {
        const [adsCatalogTemplate, adBoxTemplate] = await Promise.all([
            $.get('./templates/ads-catalog.html'),
            $.get('./templates/ad-box-partial.html')
        ]);

        templates['catalog'] = Handlebars.compile(adsCatalogTemplate);
        Handlebars.registerPartial('adBox', adBoxTemplate);
    }

    // Attach click events
    (() => {
        $('header').find('a[data-target]').click(navigateTo);
        $('#buttonLoginUser').click(login);
        $('#buttonRegisterUser').click(register);
        $('#linkLogout').click(logout);
        $('#buttonCreateAd').click(createAd);
        $('.notification').click(function () {
            $(this).hide();
        });

        showView("viewHome");
    })();

    let requester = (() => {
        // Creates the authentication header
        function makeAuth(type) {
            return type === 'basic' ?
                'Basic ' + btoa(appKey + ':' + appSecret) :
                'Kinvey ' + localStorage.getItem('authtoken');
        }

        // Creates request object to kinvey
        function makeRequest(method, module, endpoint, auth) {
            return req = {
                method,
                url: baseUrl + module + '/' + appKey + '/' + endpoint,
                headers: {
                    'Authorization': makeAuth(auth)
                }
            };
        }

        // Function to return GET promise
        function get(module, endpoint, auth) {
            return $.ajax(makeRequest('GET', module, endpoint, auth));
        }

        // Function to return POST promise
        function post(module, endpoint, auth, data) {
            let req = makeRequest('POST', module, endpoint, auth);
            req.data = data;
            return $.ajax(req);
        }

        // Function to return PUT promise
        function update(module, endpoint, auth, data) {
            let req = makeRequest('PUT', module, endpoint, auth);
            req.data = data;
            return $.ajax(req);
        }

        // Function to return DELETE promise
        function remove(module, endpoint, auth) {
            return $.ajax(makeRequest('DELETE', module, endpoint, auth));
        }

        return {
            get,
            post,
            update,
            remove  
        }
    })();

    if (localStorage.getItem('authtoken') !== null) {
        userLoggedIn();
    } else {
        userLoggedOut();
    }

    // Handle notifications
    $(document).on({
        ajaxStart: () => $("#loadingBox").show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    function showInfo(message) {
        let infoBox = $('#infoBox');
        infoBox.text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    function showError(message) {
        let errorBox = $('#errorBox');
        errorBox.text(message);
        errorBox.show();
    }

    function handleError(reason) {        
        if(reason && reason.responseJSON) {
            showError(reason.responseJSON.description);
        }
        else {
            showError(reason.toString());
        }
    }

    function showView(viewName) {
        // Hide all views and show the selected view only
        $('main > section').hide();
        $('#' + viewName).show();

        if (viewName === 'viewAds') {
            loadAds();
        }
    }

    // Shows only the correct links for a logged in user
    function userLoggedIn() {
        $('#linkHome').show();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListAds').show();
        $('#linkCreateAd').show();
        $('#linkLogout').show();
        $('#loggedInUser').show();
    }

    // Shows only the correct links for an anonymous user
    function userLoggedOut() {
        $('#linkHome').show();
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListAds').hide();
        $('#linkCreateAd').hide();
        $('#linkLogout').hide();
        $('#loggedInUser').hide();
    }

    function navigateTo(ev) {
        let target = $(ev.target).attr('data-target');
        showView(target);
    }

    // Saves username/id/authtoken to local storage
    function saveSession(data) {
        localStorage.setItem('username', data.username);
        localStorage.setItem('id', data._id);
        localStorage.setItem('authtoken', data._kmd.authtoken);
        userLoggedIn();
    }

    // Logs in the user
    async function login() {
        let form = $('#formLogin');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            if (isAuthenticated()) {
                throw new Error("Please logout first.")
            }

            let response = await requester.post('user', 'login', 'basic', {
                username,
                password
            });
            saveSession(response);
            showView('viewAds');
            showInfo('Successfully logged in!');
        } catch (e) {
            handleError(e);
        }
    }

    // Register a user
    async function register() {
        let form = $('#formRegister');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();

        try {
            if (isAuthenticated()) {
                throw new Error("Please logout first.")
            }

            let response = await requester.post('user', '', 'basic', {
                username,
                password
            });
            saveSession(response);
            showView('viewAds');
            showInfo('Successfully registered!');
        } catch (e) {
            handleError(e);
        }
    }

    // Logout a user
    async function logout() {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login first.")
            }

            await requester.post('user', '_logout', 'kinvey', {
                authtoken: localStorage.getItem('authtoken')
            });
            localStorage.clear(); // Clears all session storage on logout
            userLoggedOut();
            showView('viewHome');
            showInfo('Logout successful!')
        } catch (e) {
            handleError(e);
        }
    }

    // Load all ads
    async function loadAds() {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login.")
            }

            let ads = await requester.get('appdata', 'ads', 'kinvey')
    
            let adsModel = ads.map(ad => {
                ad.isAuthor = ad._acl.creator == localStorage.getItem('id');
                return ad;
            });
    
            let html = $(templates.catalog({
                "ads": adsModel
            }));
    
            html.find('button.ad-control.details').on('click', openAdDetails);
            html.find('button.ad-control.delete').on('click', deleteAd);
            html.find('button.ad-control.edit').on('click', openEditAdd);
    
            $('#viewAds > #content').html(html);
        } catch (err) {
            handleError(err);
        }
    }

    // Create an add
    async function createAd() {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login.")
            }

            let form = $('#formCreateAd');
            let title = form.find('input[name="title"]');
            let description = form.find('textarea[name="description"]');
            let price = form.find('input[name="price"]');
            let imageUrl = form.find('input[name="imageUrl"]');
            let publisher = localStorage.getItem('username');
    
            if (title.val().length < 4) {
                throw new Error("Title must be at least 4 symbols.");
            } else if (description.val().length < 4) {
                throw new Error("Description must be at least 4 symbols.");
            } else if (+price.val() <= 0) {
                throw new Error("Price must be positive number.");
            }

            await requester.post('appdata', 'ads', 'kinvey', {
                "title": title.val(),
                "description": description.val(),
                "price": price.val(),
                "imageUrl": imageUrl.val(),
                publishingDate: new Date(),
                publisher
            });

            showView('viewAds');
            showInfo('Successfully created!');

            title.val("");
            description.val("");
            price.val("");
            imageUrl.val("");
        } catch (e) {
            handleError(e);
        }
    }

    // Details page
    async function openAdDetails(ev) {
        if (!isAuthenticated()) {
            throw new Error("Please login.")
        }

        let target = $(ev.target);
        let adId = target.parent().attr('data-id');

        let ad = await requester.get('appdata', 'ads/' + adId, 'kinvey');

        console.log(ad);

        $('#detailsAdImage').attr('src', ad.imageUrl);
        $('#detailsAdTitle').text(ad.title);
        $('#detailsAdDescription').text(ad.description);
        $('#detailsAdPrice').text(ad.price);
        $('#detailsAdPublisher').text(ad.publisher);
        $('#detailsAdDate').text(new Date(ad.publishingDate).toLocaleDateString());

        showView('viewDetailsAd');
    }

    // Delete an add
    async function deleteAd(ev) {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login.")
            }

            let target = $(ev.target);
            let publisher = getPublisher(target);
                
            if(!isAuthor(publisher)) {
                throw new Error("You are not creator of this ad.")
            }   

            let adId = target.parent().attr('data-id');

            requester.remove("appdata", "ads/" + adId, "kinvey");
            target.parent().parent().remove();
            showInfo('Successfully deleted!');
        } catch (err) {
            handleError(err);
        }
    }

    // Edit an add
    async function editAd() {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login.")
            }

            let form = $('#formEditAd');
            let publisher = form.find('input[name="publisher"]');

            if(!isAuthor(publisher.val())) {
                throw new Error("You are not creator of this ad.")
            }   

            let id = form.find('input[name="id"]');
            let title = form.find('input[name="title"]');
            let description = form.find('textarea[name="description"]');
            let price = form.find('input[name="price"]');
            let imageUrl = form.find('input[name="imageUrl"]');

            if (title.val().length < 4) {
                throw new Error("Title must be at least 4 symbols.");
            } else if (description.val().length < 4) {
                throw new Error("Description must be at least 4 symbols.");
            } else if (+price.val() <= 0) {
                throw new Error("Price must be positive number.");
            }

            await requester.update('appdata', 'ads/' + id.val(), 'kinvey', {
                "title": title.val(),
                "description": description.val(),
                "price": +price.val(),
                "imageUrl": imageUrl.val(),
                "publisher": publisher.val()
            });

            showView("viewAds");
            showInfo('Successfully edited!');

            id.val("");
            publisher.val("");
            title.val("");
            description.val("");
            price.val("");
            imageUrl.val("");
        } catch (err) {
            handleError(err);
        }
    }

    // Open edit add view
    async function openEditAdd(ev) {
        try {
            if (!isAuthenticated()) {
                throw new Error("Please login.")
            }

            let target = $(ev.target);
            
            if(!isAuthor(getPublisher(target))) {
                throw new Error("You are not creator of this ad.")
            }

            let form = $('#formEditAd');
            let id = form.find('input[name="id"]');
            let title = form.find('input[name="title"]');
            let description = form.find('textarea[name="description"]');
            let price = form.find('input[name="price"]');
            let imageUrl = form.find('input[name="imageUrl"]');
            let publisher = form.find('input[name="publisher"]');
            form.find('#buttonEditAd').on('click', editAd);

            let adId = target.parent().attr('data-id');
            let ad = await requester.get('appdata', 'ads/' + adId, 'kinvey');

            id.val(ad._id);
            publisher.val(ad.publisher);
            title.val(ad.title);
            description.val(ad.description);
            price.val(ad.price);
            imageUrl.val(ad.imageUrl);
        } catch (err) {
            handleError(err);
        }

        showView("viewEditAd");
    }

    function isAuthenticated() {
        let authtoken = localStorage.getItem('authtoken');
        
        return authtoken != null && authtoken != 'undefined';
    }

    function isAuthor(publisher) {
        let username = localStorage.getItem('username');

        return username == publisher;
    }

    function getPublisher(target) {
        return target
                .parent()
                .parent()
                .last('div')
                .text()
                .split(" | ")[1]
                .slice(3)
                .trim();
    }
}