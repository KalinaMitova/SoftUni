const mongoose = require('mongoose');
const User = mongoose.model('User');
const encryption = require('../utilities/encryption');

const passwordsDoNotMatchMessage = 'Passwords do not match';
const authonticationErrorMessage = 'Authentication not working';

module.exports.registerGet = (req, res) => {
    res.render('user/register');
};

module.exports.registerPost = (req, res) => {
    let user = req.body;

    if (user.password && user.password !== user.confirmedPassword) {

        res.render('user/register', {
            user,
            error: passwordsDoNotMatchMessage
        });
        return;
    }

    let salt = encryption.generateSalt();
    user.salt = salt;

    if (user.password) {
        let hashedPassword = encryption.generateHashedPassword(salt, user.password);
        user.password = hashedPassword;
    }

    User.create(user)
        .then((user) => {
            req.logIn(user, (error, user) => {
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