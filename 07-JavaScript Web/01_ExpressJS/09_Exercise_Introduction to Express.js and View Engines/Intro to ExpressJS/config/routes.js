const homeHandler = require('../controllers/homeHandler');
const cubeHandler = require('../controllers/cubeHandler');

module.exports = app => {
    // Home page
    app.get('/', homeHandler.homeGet);

    // About page
    app.get('/about', homeHandler.aboutGet);

    // Create page
    app.get('/create', cubeHandler.createGet);
    app.post('/create', cubeHandler.createPost);

    // Details page
    app.get('/details/:id', cubeHandler.detailsGet);

    // Redirect to home 
    app.get('*', function (req, res) {
        res.redirect('/');
    });
};