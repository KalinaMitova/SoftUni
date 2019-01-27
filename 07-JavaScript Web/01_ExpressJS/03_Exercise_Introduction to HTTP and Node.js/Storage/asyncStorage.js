const fs = require('fs');

const asyncStorage = (function () {
    const storagePath = './data/storage.json';

    let data = {};

    const putAsync = async function (key, value) {
        const error = checkForValidKey(key, {
            isString: true,
            isExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        data[key] = value;
    };

    const getAsync = async function (key) {
        const error = checkForValidKey(key, {
            isString: true,
            isNotExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        return data[key];
    };

    const getAllAsync = async function () {
        if (Object.keys(data).length === 0) {
            return "There are no items in the storage.";
        }

        return Object.assign({}, data);
    };

    const updateAsync = async function (key, value) {
        const error = checkForValidKey(key, {
            isString: true,
            isNotExist: true
        });

        if (error) {
            throw new Error(error.message);
        }

        return data[key] = value;
    };

    const deleteAsync = async function (key) {
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

    const clearAsync = async function () {
        data = {};
    };

    const saveAsync = function () {
        return new Promise((resolve, reject) => {
            fs.writeFile(storagePath, JSON.stringify(data), (err) => {
                if (err) {
                    return reject(err.message);
                }

                return resolve();
            });
        });
    };

    const loadAsync = function () {
        return new Promise((resolve, reject) => {
            if (fs.existsSync(storagePath)) {
                fs.readFile(storagePath, 'utf8', (err, storageFile) => {
                    if (err) {
                        return reject(err.message);
                    }

                    data = JSON.parse(storageFile);
                    return resolve();
                });
            } else {
                return resolve();
            }
        });
    };

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
        putAsync,
        getAsync,
        getAllAsync,
        updateAsync,
        deleteAsync,
        clearAsync,
        saveAsync,
        loadAsync
    };
})();

module.exports = asyncStorage;