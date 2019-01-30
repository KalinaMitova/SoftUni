const controlers = require('../controllers');
const multer = require('multer');
const auth = require('../config/auth');

let upload = multer({
    dest: './content/images'
});

module.exports = (app) => {
    app.get('/', controlers.home.index);

    // User routes
    app.get('/user/register', controlers.user.registerGet);
    app.post('/user/register', controlers.user.registerPost);

    app.get('/user/login', controlers.user.loginGet);
    app.post('/user/login', controlers.user.loginPost);

    app.post('/user/logout', auth.isAthencticated, controlers.user.logoutPost);

    // Product routes
    app.get('/product/add', auth.isAthencticated, controlers.product.addGet);
    app.post('/product/add', auth.isAthencticated, upload.single('image'), controlers.product.addPost);

    app.get('/product/edit/:id', auth.isAthencticated, controlers.product.editGet);
    app.post('/product/edit/:id', auth.isAthencticated, upload.single('image'), controlers.product.editPost);

    app.get('/product/delete/:id', auth.isAthencticated, controlers.product.deleteGet);
    app.post('/product/delete/:id', auth.isAthencticated, controlers.product.deletePost);

    app.get('/product/buy/:id', auth.isAthencticated, controlers.product.buyGet);
    app.post('/product/buy/:id', auth.isAthencticated, controlers.product.buyPost);

    // Category routes
    app.get('/category/add', auth.isAthencticated, auth.isInRole('Admin'), controlers.category.addGet);
    app.post('/category/add', auth.isAthencticated, auth.isInRole('Admin'), controlers.category.addPost);

    app.get('/category/:category/products', auth.isAthencticated, controlers.category.productsByCategory);
};