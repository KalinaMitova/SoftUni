let pageService = (() => {

    function getHomePage() {

        let data = getBasicData();
        data["hasTeam"] = sessionStorage.getItem("teamId") !== 'undefined' &&
            sessionStorage.getItem("teamId") !== null;
        data["teamId"] = sessionStorage.getItem("teamId");

        this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs"
            })
            .then(function () {
                this.partial('./templates/home/home.hbs', data);
            });
    }

    function getAboutPage() {

        let data = getBasicData();

        this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs"
            })
            .then(function () {
                this.partial('./templates/about/about.hbs', data);
            });
    }

    function getLoginPage() {

        if (isAuthenticated()) {
            auth.showError("You are already logged in. Please logout first.");
            this.redirect("/");
            return;
        }

        let data = getBasicData();

        this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs",
                "loginForm": "./templates/login/loginForm.hbs"
            })
            .then(function () {
                this.partial('./templates/login/loginPage.hbs', data);
            });
    }

    function postLoginPage(ctx) {

        if (isAuthenticated()) {
            auth.showError("You are already logged in. Please logout first.");
            this.redirect("/");
            return;
        }

        let username = this.params.username;
        let password = this.params.password;

        auth.login(username, password)
            .then(function (data) {
                auth.saveSession(data);
                auth.showInfo("You have successfully logged in.");
                ctx.redirect("/");
            })
            .catch(function (err) {
                auth.handleError(err);
            });
    }

    function getRegisterPage() {

        if (isAuthenticated()) {
            auth.showError("You are already registered. Please logout first.");
            this.redirect("/");
            return;
        }

        let data = getBasicData();

        this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs",
                "registerForm": "./templates/register/registerForm.hbs"
            })
            .then(function () {
                this.partial('./templates/register/registerPage.hbs', data);
            });
    }

    function postRegisterPage(ctx) {

        if (isAuthenticated()) {
            auth.showError("You are already registered. Please logout first.");
            this.redirect("/");
            return;
        }

        let username = this.params.username;
        let password = this.params.password;
        let confirmPassword = this.params.repeatPassword;

        if(username.length < 3) {
            auth.showError("Username must be at least 3 symbols.");
            return;
        }

        if(password.length < 3) {
            auth.showError("Password must be at least 3 symbols.");
            return;
        }

        if (password !== confirmPassword) {
            auth.showError("Passwords must match!");
            return;
        }

        auth.register(username, password, confirmPassword)
            .then(function (data) {
                auth.saveSession(data);
                auth.showInfo("You have successfully registered and logged in.");
                ctx.redirect("/");
            })
            .catch(function (err) {
                auth.handleError(err);
            });
    }

    function logout() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        auth.logout();
        sessionStorage.clear();
        auth.showInfo("You have successfully logged out.");

        this.redirect("/");
    }

    async function getCatalogPage() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        try {
            let data = getBasicData();
            data['hasNoTeam'] = sessionStorage.getItem("teamId") === 'undefined' ||
                sessionStorage.getItem("teamId") === null;
            data['teams'] = await teamsService.loadTeams();

            this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs",
                "team": "./templates/catalog/team.hbs"
            }).then(function () {
                this.partial('./templates/catalog/teamCatalog.hbs', data);
            });
        } catch (err) {
            auth.showError(err);
            this.redirect("/");
        }
    }

    function getCreateTeamPage() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.");
            this.redirect('#/login');
            return;
        }

        let teamId = sessionStorage.getItem('teamId');
        if(teamId) {
            auth.showError("You are a member of a team. To create a team leave your team first.");
            this.redirect("#/catalog/:" + teamId);
            return;
        }

        let data = getBasicData();

        this.loadPartials({
            "header": "./templates/common/header.hbs",
            "footer": "./templates/common/footer.hbs",
            "createForm": "./templates/create/createForm.hbs"
        }).then(function () {
            this.partial('./templates/create/createPage.hbs', data);
        });
    }

    function postCreateTeamPage(ctx) {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        let name = this.params.name;
        let comment = this.params.comment;

        if(name.length < 3) {
            auth.showError("Name must be at least 3 symbols.");
            return;
        }

        teamsService.createTeam(name, comment)
            .then(function (data) {
                teamsService.joinTeam(data._id);
                sessionStorage.setItem('teamId', data._id);
                auth.showInfo("You are joined successfully.");

                ctx.redirect('#/catalog/:' + data._id);
            })
    }

    async function getEditTeamPage() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        try {
            let teamId = this.params["id"].slice(1);
            let userId = sessionStorage.getItem('userId');
            let team = await teamsService.loadTeamDetails(teamId);

            if (team._acl.creator !== userId) {
                auth.showError("You are not creator of this team.");
                this.redirect('#/catalog/:' + teamId);
                return;
            }

            let data = getBasicData();
            data["teamId"] = teamId;
            data["name"] = team.name;
            data["comment"] = team.comment;

            this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs",
                "editForm": "./templates/edit/editForm.hbs"
            }).then(function () {
                this.partial('./templates/edit/editPage.hbs', data);
            });
        } catch (err) {
            auth.handleError(err);
            this.redirect("/");
        }
    }

    function postEditTeamPage(ctx) {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        let teamId = this.params["id"].slice(1);
        let name = this.params['name'];
        let comment = this.params['comment'];

        if(name.length < 3) {
            auth.showError("Name must be at least 3 symbols.");
            return;
        }

        teamsService.loadTeamDetails(teamId)
            .then((data) => {

                let creatorId = data._acl.creator;
                let userId = sessionStorage.getItem("userId");

                if (userId !== creatorId) {
                    auth.showError("You are not creator of this team.");
                    ctx.redirect('#/catalog/:' + teamId);
                    return;
                }

                teamsService.edit(teamId, name, comment)
                    .then(function () {
                        auth.showInfo("Team is successfully edited.");
                        ctx.redirect('#/catalog/:' + teamId);
                    });
            }).catch(function (err) {
                auth.handleError(err);
                ctx.redirect("/");
            });;
    }

    async function getDetailsPage() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        try {
            let teamId = this.params['id'].slice(1);
            let team = await teamsService.loadTeamDetails(teamId);

            let data = getBasicData();
            data['teamId'] = team._id;
            data['name'] = team.name;
            data["comment"] = team.comment;
            data['isAuthor'] = team._acl.creator === sessionStorage.getItem('userId');
            data['isOnTeam'] = teamId === sessionStorage.getItem('teamId');

            data['members'] = (await requester.get('user', '', 'kinvey'))
                .filter(function(user) {
                    return user.teamId === teamId;
                });

            this.loadPartials({
                "header": "./templates/common/header.hbs",
                "footer": "./templates/common/footer.hbs",
                "teamMember": "./templates/catalog/teamMember.hbs",
                "teamControls": "./templates/catalog/teamControls.hbs"
            }).then(function () {
                this.partial('./templates/catalog/details.hbs', data);
            });
        } catch (err) {
            auth.handleError(err);
            this.redirect('/');
        }
    }

    function joinTeam() {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        let teamId = this.params['id'].slice(1);
        teamsService.joinTeam(teamId);
        sessionStorage.setItem('teamId', teamId);
        auth.showInfo("You are successfully join to this team.");

        this.redirect("#/catalog/:" + teamId);
    }

    function leaveTeam(ctx) {

        if (!isAuthenticated()) {
            auth.showError("You are not logged in. Please login.")
            this.redirect('#/login');
            return;
        }

        if (!sessionStorage.getItem('teamId')) {
            auth.showError("You are not in team. Please join а team first.")
            this.redirect('#/catalog');
            return;
        }

        teamsService.leaveTeam()
            .then(function () {
                auth.showInfo("You have successfully left the team.");

                let teamId = sessionStorage.getItem('teamId');
                sessionStorage.removeItem('teamId');
                ctx.redirect("#/catalog/:" + teamId);
            })
            .catch(function (err) {
                auth.handleError(err);
                ctx.redirect('/');
            });
    }

    function getBasicData() {

        return {
            "loggedIn": sessionStorage.getItem("authtoken") !== 'undefined' &&
                sessionStorage.getItem("authtoken") !== null,
            "username": sessionStorage.getItem('username')
        };
    }

    function isAuthenticated() {

        return sessionStorage.getItem("authtoken") !== 'undefined' &&
            sessionStorage.getItem("authtoken") !== null;
    }

    return {
        getHomePage,
        getAboutPage,
        getLoginPage,
        postLoginPage,
        getRegisterPage,
        postRegisterPage,
        logout,
        getCatalogPage,
        getCreateTeamPage,
        postCreateTeamPage,
        getEditTeamPage,
        postEditTeamPage,
        getDetailsPage,
        joinTeam,
        leaveTeam,
    };
})();