const path = require('path');

const config = {
    development: {
        connectionString: 'mongodb://localhost:27017/ShopStopDatabase',
        rootPath: path.normalize(path.join(__dirname, '../')),
    },
    production: {}
};

module.exports = config;