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

    let product = await Product.create(productObj);
    let category = await Category.findById(product.category);
    category.products.push(product._id);
    category.save();
    res.redirect('/');
};

module.exports.editGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            Category.find()
                .then((categories) => {
                    res.render('products/edit', {
                        product,
                        categories
                    });
                })
        });
};

module.exports.editPost = async (req, res) => {
    let id = req.params.id;
    let editedProduct = req.body;

    let product = await Product.findById(id);
    if (!product) {
        res.redirect('/?error=' + encodeURIComponent('Product was not found!'));
        return;
    }

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
};

module.exports.deleteGet = (req, res) => {
    let id = req.params.id;

    Product.findById(id)
        .then((product) => {
            if (!product) {
                res.sendStatus(404);
                return;
            }

            res.render('products/delete', {
                product,
            });
        });
};

module.exports.deletePost = async (req, res) => {
    let id = req.params.id;

    Product.findByIdAndDelete(id, (err, product) => {

        Category.findById(product.category)
            .then((category) => {
                let index = category.products.indexOf(product._id);
                if (index >= 0) {
                    category.products.splice(index, 1);
                }


                category.save();

                const filePath = path.normalize(path.join(__dirname, '../', product.image));

                console.log(filePath);
                fs.unlink(filePath, (err) => {
                    res.redirect('/?success=' + encodeURIComponent('Product was deleted successfully!'));
                });
            });
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