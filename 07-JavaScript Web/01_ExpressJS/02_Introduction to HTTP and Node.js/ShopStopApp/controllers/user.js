const mongoose = require('mongoose');
const User = mongoose.model('User');
const encryption = require('../utilities/encryption');

const passwordsDoNotMatchMessage = 'Passwords do not match';
const authonticationErrorMessage = 'Authentication not working';
const userAlreadyExist = 'User "{0}" already exist!';

module.exports.registerGet = (req, res) => {
    res.render('user/register');
};

module.exports.registerPost = (req, res) => {
    let userModel = req.body;

    if (userModel.password && userModel.confirmedPassword && userModel.password !== userModel.confirmedPassword) {

        res.render('user/register', {
            userModel,
            error: passwordsDoNotMatchMessage
        });
        return;
    }

    User.find({
            username: userModel.username
        })
        .then((user) => {
            if (user) {
                res.render('user/register', {
                    userModel,
                    error: userAlreadyExist.replace('{0}', userModel.username)
                });
                return;
            }

            let salt = encryption.generateSalt();
            userModel.salt = salt;
            userModel.password = encryption.generateHashedPassword(salt, userModel.password);

            User.create(userModel)
                .then((createdUser) => {
                    req.logIn(createdUser, (error, loggedInUser) => {
                        if (error) {
                            res.render('user/register', {
                                error: authonticationErrorMessage
                            });
                            return;
                        }

                        res.redirect('/');
                    });
                })
                .catch((error) => {
                    let errorMessages = Object.keys(error.errors)
                        .map(key => error.errors[key].message)
                        .join(' ');

                    res.render('user/register', {
                        error: errorMessages
                    });
                });
        })
        .catch((error) => {
            let errorMessages = Object.keys(error.errors)
                .map(key => error.errors[key].message)
                .join(' ');

            res.render('user/register', {
                error: errorMessages
            });
        });
};

module.exports.loginGet = (req, res) => {
    res.render('user/login');
};

module.exports.loginPost = (req, res) => {
    let userToLogin = req.body;

    User.findOne({
            username: userToLogin.username
        })
        .then((user) => {
            if (!user || !user.authenticate(userToLogin.password)) {
                res.render('user/login', {
                    error: "Invalid credentials!"
                });
                return;
            }

            req.logIn(user, (error, user) => {
                if (error) {
                    res.render('user/login', {
                        error: authonticationErrorMessage
                    });
                    return;
                }

                res.redirect('/');
            });
        })
        .catch(error => {
            res.render('user/login', {
                error
            });
        });
};

module.exports.logoutPost = (req, res) => {
    req.logout();
    res.redirect('/');
};