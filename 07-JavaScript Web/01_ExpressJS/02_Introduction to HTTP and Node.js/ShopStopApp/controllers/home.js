const Product = require('../models/Product');

module.exports.index = (req, res) => {

    let queryData = req.query;

    Product.find({buyer: null})
        .populate('category')
        .then((products) => {
            let data = {
                products
            };
            
            if (queryData.error) {
                data.error = queryData.error;
            } else if (queryData.success) {
                data.success = queryData.success;
            } 
            
            if (queryData.query) {
                data.products = data.products.filter((p) => {
                    return p.name.toLowerCase().includes(queryData.query.toLowerCase());
                });
            }

            res.render('home/index', data);
        });
};