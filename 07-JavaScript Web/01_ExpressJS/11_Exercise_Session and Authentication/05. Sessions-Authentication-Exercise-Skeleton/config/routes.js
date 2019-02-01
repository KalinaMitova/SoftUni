const restrictedPages = require('./auth');
const userController = require('../controllers/user');
const homeController = require('../controllers/home');
const carController = require('../controllers/car');

module.exports = app => {

    // Home route
    app.get('/', homeController.index);

    // User routes
    app.get('/user/register', restrictedPages.isAnonymous, userController.registerGet);
    app.post('/user/register', restrictedPages.isAnonymous, userController.registerPost);

    app.get('/user/login', restrictedPages.isAnonymous, userController.loginGet);
    app.post('/user/login', restrictedPages.isAnonymous, userController.loginPost);

    app.post('/user/logout', restrictedPages.isAuthed, userController.logout);

    // Car routes
    app.get('/car/add', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), carController.addGet);
    app.post('/car/add', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), carController.addPost);

    app.get('/car/edit/:id', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), carController.editGet);
    app.post('/car/edit/:id', restrictedPages.isAuthed, restrictedPages.hasRole('Admin'), carController.editPost);

    app.get('/car/all', carController.allGet);

    // Rent

    app.get('/car/rent/:id', restrictedPages.isAuthed, carController.rentGet);
    app.post('/car/rent/:id', restrictedPages.isAuthed, carController.rentPost);

    app.get('/user/rents', restrictedPages.isAuthed, userController.allRentsGet);

    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};