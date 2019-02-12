const encryption = require('../util/encryption');
const User = require('mongoose').model('User');

module.exports = {
    registerGet: (req, res) => {
        res.render('users/register');
    },
    registerPost: async (req, res) => {
        const reqUser = req.body;
        const salt = encryption.generateSalt();
        const hashedPass =
            encryption.generateHashedPassword(salt, reqUser.password);
        try {
            const user = await User.create({
                username: reqUser.username,
                hashedPass,
                salt,
                firstName: reqUser.firstName,
                lastName: reqUser.lastName,
                roles: ['User']
            });
            req.logIn(user, (err, user) => {
                if (err) {
                    res.locals.globalError = err;
                    res.render('users/register', user);
                } else {
                    res.redirect('/');
                }
            });
        } catch (e) {
            console.log(e);
            res.locals.globalError = e;
            res.render('users/register');
        }
    },
    loginGet: (req, res) => {
        res.render('users/login');
    },
    loginPost: async (req, res) => {
        const reqUser = req.body;
        try {
            const user = await User.findOne({
                username: reqUser.username
            });
            if (!user) {
                errorHandler('Invalid user data');
                return;
            }
            if (!user.authenticate(reqUser.password)) {
                errorHandler('Invalid user data');
                return;
            }
            req.logIn(user, (err, user) => {
                if (err) {
                    errorHandler(err);
                } else {
                    res.redirect('/');
                }
            });
        } catch (e) {
            errorHandler(e);
        }

        function errorHandler(e) {
            console.log(e);
            res.locals.globalError = e;
            res.render('users/login');
        }
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    blockUser: async (req, res) => {
        try {
            const username = req.params.username;
            const receiverId = req.body.receiverId;

            req.user.blockedUsers.push(username);
            await req.user.save();

            res.redirect(`/threads/${receiverId}`);
        } catch (error) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    },
    unblockUser: async (req, res) => {
        try {
            const username = req.params.username;
            const receiverId = req.body.receiverId;

            req.user.blockedUsers = req.user.blockedUsers
                .filter(blockedUser => blockedUser !== username);

            await req.user.save();

            res.redirect(`/threads/${receiverId}`);
        } catch (error) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    },
};