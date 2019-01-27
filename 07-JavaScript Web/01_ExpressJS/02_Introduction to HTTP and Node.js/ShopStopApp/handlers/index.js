const homeHandler = require('./home');
const productHandler = require('./product');
const categoryHandler = require('./category');
const staticFiles = require('./static-files');

module.exports = [
    homeHandler,
    productHandler,
    categoryHandler,
    staticFiles,
];