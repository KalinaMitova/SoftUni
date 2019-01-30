const notify = require('../controllers/notificationHandler');
const mongoose = require('mongoose');
const Cube = mongoose.model('Cube');

const createGet = function (req, res) {
    res.render('../views/create');
};

const createPost = function (req, res) {
    let cube = req.body;
    cube.difficulty = parseInt(cube.difficulty);

    const errMessage = validateCube(cube);
    if (errMessage) {
        notify.show(res, 'create', 'error', errMessage, cube);
        return;
    }

    Cube.create(cube)
        .then((newCube) => {
            Cube.find({})
                .then((cubes) => {
                    notify.show(res, 'index', 'success', `Cube '${newCube.name}' is created successfully!`, {
                        cubes
                    });
                })
                .catch((err) => {
                    notify.show(res, 'create', 'error', err.message, cube);
                });
        })
        .catch((err) => {
            notify.show(res, 'create', 'error', err.message, cube);
        });
};

const detailsGet = function (req, res) {
    const id = req.params.id;

    Cube.findById(id)
        .then((cube) => {
            if (!cube) {
                notify.show(res, 'index', 'error', 'Cube not found!');
                return;
            }

            res.render('../views/details', cube);
        })
        .catch((err) => {
            Cube.find({})
                .then((cubes) => {
                    notify.show(res, 'index', 'error', err.message, {
                        cubes
                    });
                });
        });
};

function validateCube(cube) {
    const {
        name,
        description,
        imageUrl,
        difficulty
    } = cube;

    if (!name) {
        return 'Name is required!';
    }

    if (name.length < 3 || name.length > 15) {
        return 'Name must be between 3 and 15 symbols!';
    }

    if (!description) {
        return 'Description is required!';
    }

    if (description.length < 20 || description.length > 300) {
        return 'Description must be between 20 and 300 symbols';
    }

    if (!imageUrl) {
        return 'Image URL is required!';
    }

    if (!((imageUrl.startsWith('https://') ||
                imageUrl.startsWith('http://')) &&
            (imageUrl.endsWith('.jpg') ||
                imageUrl.endsWith('.png')))) {
        return "Image URL must start with https://' or 'Image URL must end with .jpg or .png";
    }

    if (!difficulty) {
        return 'Difficulty URL is required!';
    }

    if (difficulty < 1 || difficulty > 6) {
        return 'Difficulty must be between 1 and 6 inclusive!';
    }

    return null;
}

module.exports = {
    createGet,
    createPost,
    detailsGet,
};