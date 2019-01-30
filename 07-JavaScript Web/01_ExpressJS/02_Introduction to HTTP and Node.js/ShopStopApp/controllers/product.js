const fs = require('fs');
const path = require('path');
const Product = require('../models/Product');
const Category = require('../models/Category');

module.exports.addGet = (req, res) => {
    Category.find({})
        .then((categories) => {
            res.render('products/add', {
                categories
            });
        });
};

module.exports.addPost = async (req, res) => {
    let productObj = req.body;

    productObj.image = '/' + req.file.path;
    productObj.creator = req.user._id;

    let product = await Product.create(productObj);
    let category = await Category.findById(product.category);
    category.products.push(product._id);
    category.save();
    res.redirect('/');
};

module.exports.editGet = (req, res) => {
    let id = req.params.id;

    Product.findOne({
            _id: id,
            buyer: null
        })
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            if (product.creator.equals(req.user._id) ||
                req.user.roles.indexOf('Admin') > -1) {
                Category.find()
                    .then((categories) => {
                        res.render('products/edit', {
                            product,
                            categories
                        });
                    })
            } else {
                res.render('home/index', {
                    error: "You are not creator or admin to EDIT this product!"
                });
            }
        });
};

module.exports.editPost = async (req, res) => {
    let id = req.params.id;
    let editedProduct = req.body;

    let product = await Product.findOne({
        _id: id,
        buyer: null
    });
    if (!product) {
        res.redirect('/?error=' + encodeURIComponent('Product was not found!'));
        return;
    }

    if (product.creator.equals(req.user._id) ||
        req.user.roles.indexOf('Admin') > -1) {

        product.name = editedProduct.name;
        product.description = editedProduct.description;
        product.price = editedProduct.price;

        if (req.file) {
            product.image = '/' + req.file.path;
        }

        // First we check if the category is changed.
        if (product.category.toString() !== editedProduct.category) {
            // If So find the "current" and "next" category.
            Category.findById(product.category)
                .then((currentCategory) => {
                    Category.findById(editedProduct.category)
                        .then((nextCategory) => {
                            let index = currentCategory.products.indexOf(product._id);
                            if (index >= 0) {
                                // Remove product specified
                                // from current category's list of products.
                                currentCategory.products.splice(index, 1);
                            }

                            currentCategory.save();

                            // Add products reference to the "new" category.
                            nextCategory.products.push(product._id);
                            nextCategory.save();

                            product.category = editedProduct.category;

                            product.save()
                                .then(() => {
                                    res.redirect('/?success=' + encodeURIComponent('Product was edited successfully!'));
                                });
                        });
                });
        } else {
            product.save()
                .then(() => {
                    res.redirect('/?success=' + encodeURIComponent('Product was edited successfully!'));
                });
        }
    } else {
        res.render('home/index', {
            error: "You are not creator or admin to EDIT this product!"
        });
    }
};

module.exports.deleteGet = (req, res) => {
    let id = req.params.id;

    Product.findOne({
            _id: id,
            buyer: null
        })
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            if (product.creator.equals(req.user._id) ||
                req.user.roles.indexOf('Admin') > -1) {
                res.render('products/delete', {
                    product,
                });
            } else {
                res.render('home/index', {
                    error: "You are not creator or admin to DELETE this product!"
                });
            }
        });
};

module.exports.deletePost = async (req, res) => {
    let id = req.params.id;

    Product.findOne({
        _id: id,
        buyer: null
    }, (err, product) => {

        if (product.creator.equals(req.user._id) ||
            req.user.roles.indexOf('Admin') > -1) {

            product.remove()
                .then(() => {
                    Category.findById(product.category)
                        .then((category) => {
                            let index = category.products.indexOf(product._id);
                            if (index >= 0) {
                                category.products.splice(index, 1);
                            }

                            category.save();

                            const filePath = path.normalize(path.join(__dirname, '../', product.image));

                            fs.unlink(filePath, (err) => {
                                res.redirect('/?success=' + encodeURIComponent('Product was deleted successfully!'));
                            });
                        });
                });
        } else {
            res.render('home/index', {
                error: "You are not creator or admin to DELETE this product!"
            });
        }
    });
}

module.exports.buyGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            res.render('products/buy', {
                product,
            });
        });
};

module.exports.buyPost = (req, res) => {
    let productId = req.params.id;

    Product.findById(productId)
        .then((product) => {
            if (product.buyer) {
                let error = `error=${encodeURIComponent('Product was already bought!')}`;
                res.redirect(`/?${error}`);
                return;
            }

            product.buyer = req.user._id;
            product.save()
                .then(() => {
                    req.user.boughtProducts.push(productId);
                    req.user.save()
                        .then(() => {
                            res.redirect('/');
                        });
                })
        });
};