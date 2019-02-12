module.exports = {
    showError: async (res, message, data, view = "home/index") => {
        data = data || {};
        data.notification = {
            message,
            type: 'error',
        }

        res.render(view, data);
    },
    showSuccess: async (res, message, data, view = "home/index") => {
        data = data || {};
        data.notification = {
            message,
            type: 'success',
        }
        res.render(view, data);
    },
    showInfo: async (res, message, data, view = "home/index") => {
        data = data || {};
        data.notification = {
            message,
            type: 'info',
        }
        res.render(view, data);
    },
};