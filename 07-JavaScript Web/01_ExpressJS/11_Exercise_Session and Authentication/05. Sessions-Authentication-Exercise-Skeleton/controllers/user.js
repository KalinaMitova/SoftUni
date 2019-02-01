const mongoose = require('mongoose');
const User = mongoose.model('User');
const Rent = mongoose.model('Rent');
const encryption = require('../util/encryption');

const homePage = 'home/index';
const registerPage = 'user/register';
const loginPage = 'user/login';
const userRentsPage = 'user/rented';

module.exports = {
    registerGet: (req, res) => {
        res.render(registerPage);
    },
    registerPost: async (req, res) => {
        let userModel = req.body;

        try {
            if (!userModel.username || !userModel.password || !userModel.repeatPassword) {
                userModel.error = "Username and passwords are required.";
                res.render(registerPage, userModel);
                return;
            }

            if (userModel.password !== userModel.repeatPassword) {
                userModel.error = "Passwords did not match.";
                res.render(registerPage, userModel);
                return;
            }

            let user = await User.findOne({
                username: userModel.username
            });

            if (user) {
                userModel.error = "Username already exist!";
                res.render(registerPage, userModel);
                return;
            }

            const salt = encryption.generateSalt();
            const hashedPass = encryption.generateHashedPassword(salt, userModel.password);

            let createdUser = await User.create({
                username: userModel.username,
                hashedPass: hashedPass,
                salt: salt,
                firstName: userModel.firstName,
                lastName: userModel.lastName,
                roles: ["User"],
            });

            req.logIn(createdUser, (err) => {
                if (err) {
                    throw err;
                }

                res.redirect('/');
            });

        } catch (error) {
            console.log(error);
            userModel.error = "Something went wrong while registering user."
            res.render(registerPage, userModel);
        }
    },
    loginGet: (req, res) => {
        res.render('user/login');
    },
    loginPost: async (req, res) => {
        let loginModel = req.body;

        try {
            if (!loginModel.username || !loginModel.password) {
                loginModel.error = "Username and password are required."
                res.render(loginPage, loginModel);
                return;
            }

            const user = await User.findOne({
                username: loginModel.username
            });

            if (!user) {
                loginModel.error = "Invalid credentials."
                res.render(loginPage, loginModel);
                return;
            }

            const hashedPass = encryption.generateHashedPassword(user.salt, loginModel.password);

            if (hashedPass !== user.hashedPass) {
                loginModel.error = "Invalid credentials."
                res.render(loginPage, loginModel);
                return;
            }

            req.logIn(user, (err) => {
                if (err) {
                    throw err;
                }

                res.redirect('/');
            });

        } catch (error) {
            console.log(error);
            loginModel.error = "Something went wrong while signing in."
            res.render(loginPage, loginModel);
        }
    },
    logout: (req, res) => {
        req.logOut();
        res.redirect('/');
    },
    allRentsGet: async (req, res) => {
        const userId = req.user._id;

        try {
            const rents = await Rent.find({
                    tenant: userId
                })
                .populate('car');

            res.render(userRentsPage, {
                rents
            });
        } catch (error) {
            console.log(error);
            res.render(homePage, {
                error: "Something went wrong."
            });
        }
    },
};