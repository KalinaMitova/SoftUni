const controllers = require('../controllers');
const restrictedPages = require('./auth');

module.exports = app => {

    // Home route
    app.get('/', controllers.home.index);

    // User route
    app.get('/users/register', restrictedPages.isAnonymous, controllers.user.registerGet);
    app.post('/users/register', restrictedPages.isAnonymous, controllers.user.registerPost);

    app.get('/users/login', restrictedPages.isAnonymous, controllers.user.loginGet);
    app.post('/users/login', restrictedPages.isAnonymous, controllers.user.loginPost);

    app.post('/users/logout', restrictedPages.isAuthed, controllers.user.logout);

    app.post('/block/:username', restrictedPages.isAuthed, controllers.user.blockUser);
    app.post('/unblock/:username', restrictedPages.isAuthed, controllers.user.unblockUser);

    // Thread routes
    app.post('/threads/find', restrictedPages.isAuthed, controllers.thread.searchThreadPost);

    app.get('/threads/:receiverId', restrictedPages.isAuthed, controllers.thread.threadGet);
    app.post('/threads/:receiverId', restrictedPages.isAuthed, controllers.thread.sendMessage);

    app.post('/threads/remove/:threadId', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), controllers.thread.deleteThread);

    // Not found
    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};