module.exports = {
    isAuthed: (req, res, next) => {
        if (req.user) {
            next();
        } else {
            res.redirect('/user/login');
        }
    },
    hasRole: (role) => (req, res, next) => {
        if (req.user &&
            req.user.roles.indexOf(role) > -1) {
            next();
        } else {
            res.redirect('/');
        }
    },
    isAnonymous: (req, res, next) => {
        if (!req.user) {
            next();
        } else {
            res.redirect('/');
        }
    },
    isAuthorOrAdmin: (req, res, next) => {
        if (!req.user) {
            res.redirect('/user/login');
            return;
        }

        const articleId = req.params.id;

        if (req.user.roles.indexOf('Admin') > -1 ||
            req.user.articles.indexOf(articleId) > -1) {
            next();
        } else {
            res.redirect('/');
        }
    }
}