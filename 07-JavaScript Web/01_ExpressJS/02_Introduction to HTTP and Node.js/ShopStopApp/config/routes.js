const controlers = require('../controllers');
const multer = require('multer');

let upload = multer({
    dest: './content/images'
});

module.exports = (app) => {
    app.get('/', controlers.home.index);

    app.get('/product/add', controlers.product.addGet);
    app.post('/product/add', upload.single('image'), controlers.product.addPost);

    app.get('/product/edit/:id', controlers.product.editGet);
    app.post('/product/edit/:id', upload.single('image'), controlers.product.editPost);

    app.get('/product/delete/:id', controlers.product.deleteGet);
    app.post('/product/delete/:id', controlers.product.deletePost);

    app.get('/product/buy/:id', controlers.product.buyGet);

    app.get('/category/add', controlers.category.addGet);
    app.post('/category/add', controlers.category.addPost);
    app.get('/category/:category/products', controlers.category.productsByCategory);
};