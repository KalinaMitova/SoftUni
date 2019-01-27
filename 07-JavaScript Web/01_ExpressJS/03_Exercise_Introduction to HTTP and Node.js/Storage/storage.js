const fs = require('fs');

const storage = (function () {
    const storagePath = './data/storage.json';
    let data = {};

    const put = function (key, value) {
        const error = checkForValidKey(key, {
            isString: true,
            isExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        data[key] = value;
    };

    const get = function (key) {
        const error = checkForValidKey(key, {
            isString: true,
            isNotExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        return data[key];
    };

    const getAll = function () {
        if (Object.keys(data).length === 0) {
            return "There are no items in the storage.";
        }

        return Object.assign({}, data);
    };

    const update = function (key, value) {
        const error = checkForValidKey(key, {
            isString: true,
            isNotExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        return data[key] = value;
    };

    const del = function (key) {
        const error = checkForValidKey(key, {
            isString: true,
            isNotExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        data = Object.keys(data)
            .reduce((acc, k) => {
                if (k !== key) {
                    acc[k] = data[k];
                }

                return acc;
            }, {});
    };

    const clear = function () {
        data = {};
    };

    const save = function () {
        fs.writeFileSync(storagePath, JSON.stringify(data));
    };

    const load = function () {
        if (fs.existsSync(storagePath)) {
            const storageFile = fs.readFileSync(storagePath);
            data = JSON.parse(storageFile);
        }
    };

    // Key validation functions
    function checkForValidKey(key, options) {
        options = options || {
            isString: true,
            isExist: false,
            isNotExist: false
        };

        let error = {};

        if (options.isString) {
            if (typeof key !== typeof "") {
                error.message = 'The key must be a string!';
                return error;
            }
        }
        if (options.isExist) {
            if (Object.keys(data).indexOf(key) >= 0) {
                error.message = 'This key already exist!';
                return error;
            }
        }
        if (options.isNotExist) {
            if (Object.keys(data).indexOf(key) < 0) {
                error.message = 'This key not exist!';
                return error;
            }
        }

        return null;
    }

    return {
        put,
        get,
        getAll,
        update,
        delete: del,
        clear,
        save,
        load
    };
})();

module.exports = storage;