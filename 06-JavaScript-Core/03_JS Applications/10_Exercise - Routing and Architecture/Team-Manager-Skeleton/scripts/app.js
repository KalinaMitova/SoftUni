$(() => {
    const app = Sammy('#main', function () {

        // Initialize handlebars
        this.use('Handlebars', 'hbs');

        // home
        this.get('/index.html', pageService.getHomePage);
        this.get('#/home', pageService.getHomePage);
        this.get('/', pageService.getHomePage);

        // about
        this.get('#/about', pageService.getAboutPage);

        // login
        this.get('#/login', pageService.getLoginPage);
        this.post('#/login', pageService.postLoginPage);

        // register        
        this.get('#/register', pageService.getRegisterPage);
        this.post('#/register', pageService.postRegisterPage);

        // logout
        this.get('#/logout', pageService.logout);

        // catalog
        this.get('#/catalog', pageService.getCatalogPage);

        // create
        this.get('#/create', pageService.getCreateTeamPage);
        this.post('#/create', pageService.postCreateTeamPage);

        // edit
        this.get('#/edit/:id', pageService.getEditTeamPage);
        this.post('#/edit/:id', pageService.postEditTeamPage);

        // details
        this.get('#/catalog/:id', pageService.getDetailsPage);

        // join
        this.get('#/join/:id', pageService.joinTeam);

        // leave
        this.get('#/leave', pageService.leaveTeam);
    });

    app.run();
});