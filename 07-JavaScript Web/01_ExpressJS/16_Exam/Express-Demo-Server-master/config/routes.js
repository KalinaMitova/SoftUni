const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {

    // Home route
    app.get('/', controllers.home.index);

    // User routes
    app.get('/user/register', restrictedPages.isAnonymous, controllers.user.registerGet);
    app.post('/user/register', restrictedPages.isAnonymous, controllers.user.registerPost);

    app.get('/user/login', restrictedPages.isAnonymous, controllers.user.loginGet);
    app.post('/user/login', restrictedPages.isAnonymous, controllers.user.loginPost);

    app.post('/user/logout', restrictedPages.isAuthed, controllers.user.logout);

    app.get('/user/profile', restrictedPages.isAuthed, controllers.user.profileGet);

    app.get('/user/project/all', restrictedPages.isAuthed, restrictedPages.hasRole('User'), controllers.user.projectsGet);
    app.get('/user/team/all', restrictedPages.isAuthed, restrictedPages.hasRole('User'), controllers.user.teamsGet);

    app.post('/user/team/leave/:teamId', restrictedPages.isAuthed, controllers.user.leaveTeamPost);

    // Admin routes
    app.get('/admin/team/create', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.createTeamGet);
    app.post('/admin/team/create', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.createTeamPost);

    app.get('/admin/project/create', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.createProjectGet);
    app.post('/admin/project/create', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.createProjectPost);

    app.get('/admin/project/distribute', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.projectDistributeGet);
    app.post('/admin/project/distribute', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.projectDistributePost);

    app.get('/admin/team/distribute', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.teamDistributeGet);
    app.post('/admin/team/distribute', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.admin.teamDistributePost);

    app.all('*', (req, res) => {
        res.status(404);
        res.render('common/notFound');
    });
};