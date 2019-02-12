const notify = require('../common/notificationHandler');

module.exports = {
    isAuthed: (req, res, next) => {
        if (req.isAuthenticated()) {
            next();
        } else {
            notify.showInfo(res, 'You should login first!', null, 'users/login');
        }
    },
    hasRole: (role) => (req, res, next) => {
        if (req.isAuthenticated() &&
            req.user.roles.indexOf(role) > -1) {
            next();
        } else {
            notify.showError(res, `You don't have rights for this page!`, null, 'home/index');
        }
    },
    isAnonymous: (req, res, next) => {
        if (!req.isAuthenticated()) {
            next();
        } else {
            notify.showInfo(res, `Logout first!`, null, 'home/index');
        }
    },
}