const homeController = require('../controllers/home');
const userController = require('../controllers/user');
const articleController = require('../controllers/article');
const restrictedPages = require('../config/auth');

module.exports = (app) => {

    // Home route
    app.get('/', homeController.index);

    // User routes
    app.get('/user/register', restrictedPages.isAnonymous, userController.registerGet);
    app.post('/user/register', restrictedPages.isAnonymous, userController.registerPost);

    app.get('/user/login', restrictedPages.isAnonymous, userController.loginGet);
    app.post('/user/login', restrictedPages.isAnonymous, userController.loginPost);

    app.get('/user/logout', restrictedPages.isAuthed, userController.logout);

    // Article routes
    app.get('/article/create', restrictedPages.isAuthed, articleController.createGet);
    app.post('/article/create', restrictedPages.isAuthed, articleController.createPost);

    app.get('/article/edit/:id', restrictedPages.isAuthed, restrictedPages.isAuthorOrAdmin, articleController.editGet);
    app.post('/article/edit/:id', restrictedPages.isAuthed, restrictedPages.isAuthorOrAdmin, articleController.editPost);

    app.get('/article/delete/:id', restrictedPages.isAuthed, restrictedPages.isAuthorOrAdmin, articleController.deleteGet);
    app.post('/article/delete/:id', restrictedPages.isAuthed, restrictedPages.isAuthorOrAdmin, articleController.deletePost);

    app.get('/article/details/:id', articleController.detailsGet);

    app.all('*', (req, res) => {
        res.redirect('/');
    });
};