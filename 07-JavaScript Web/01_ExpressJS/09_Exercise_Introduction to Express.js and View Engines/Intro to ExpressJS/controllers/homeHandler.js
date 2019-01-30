const mongoose = require('mongoose');
const notify = require('../controllers/notificationHandler');
const Cube = mongoose.model('Cube');

const homeGet = function (req, res) {
    let condition = {};

    const params = req.query;
    
    if (params.search) {
        let regexp = new RegExp(params.search, 'i');
        condition.name = regexp;
    }

    if (params.from) {
        condition.difficulty = {
            '$gte': parseInt(params.from)
        };
    }

    if (params.to) {
        condition.difficulty = {
            '$lte': parseInt(params.to)
        };
    }

    Cube.find(condition)
        .then((cubes) => {
            res.render('../views/index', {
                cubes
            });
        })
        .catch((err) => {
            notify.show(res, 'index', 'error', err.message);
        });
};

const aboutGet = function (req, res) {
    res.render('../views/about');
};

module.exports = {
    homeGet,
    aboutGet,
};