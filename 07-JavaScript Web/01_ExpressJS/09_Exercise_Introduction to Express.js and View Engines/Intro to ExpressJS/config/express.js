const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');

module.exports = app => {
    app.engine('.hbs', handlebars({
        defaultLayout: 'main',
        extname: '.hbs',
        helpers: {
            is: function (a, b, opts) {
                if (a == b) {
                    return opts.fn(this)
                } else {
                    return opts.inverse(this)
                }
            }
        }
    }));

    app.use(bodyParser.urlencoded({
        extended: true
    }));

    app.set('view engine', '.hbs');

    app.use(express.static('./static'));
};