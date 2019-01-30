const mongoose = require('mongoose');
mongoose.Promise = global.Promise;

const connect = (config) => {
    mongoose.connect(config.connectionString, {
        useNewUrlParser: true
    });

    let database = mongoose.connection;

    database.on('err', (err) => {
        console.log(err);
    });

    database.once('open', (err) => {
        if (err) {
            console.log(err);
            return;
        }

        console.log('Connected!');
    });

    require('../models/Product');
    require('../models/Category');
    require('../models/User').seedAdminUser();
};

module.exports = connect;