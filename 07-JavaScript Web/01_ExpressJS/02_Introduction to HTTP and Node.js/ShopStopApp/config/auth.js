module.exports = {
    isAthencticated: (req, res, next) => {
        if (req.isAuthenticated()) {
            next();
        } else {
            // If not authenticated redirect to login.
            res.redirect('/user/login');
        }
    },
    isInRole: (role) => {
        return (req, res, next) => {
            if (req.user && req.user.roles.indexOf(role) > -1) {
                next();
            } else {
                // If not authorized redirect to login proper account.
                res.redirect('/');
            }
        }
    }
};