const show = function (res, page, type, message, data) {
    res.locals.notification = {
        type,
        message
    };

    res.render(`../views/${page}`, data);
};

module.exports = {
    show
};