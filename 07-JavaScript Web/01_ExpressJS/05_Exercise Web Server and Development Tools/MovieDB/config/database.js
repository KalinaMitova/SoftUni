const fs = require('fs');
const path = require('path');

const dbConnection = (function () {
    const dbPath = path.join(__dirname, '/database.json');

    const loadFiles = function () {
        if (!fs.existsSync(dbPath)) {
            fs.writeFileSync(dbPath, '[]');
            return [];
        }

        let json = fs.readFileSync(dbPath).toString() || '[]';
        let data = JSON.parse(json);
        return data;
    };

    const saveChanges = function (data) {
        let json = JSON.stringify(data);
        fs.writeFileSync(dbPath, json);
    };

    return {
        loadFiles,
        saveChanges
    };
})();

const database = (function () {
    const getAll = function () {
        let movies = dbConnection.loadFiles();
        return movies;
    };

    const getById = function (id) {
        let movies = dbConnection.loadFiles();

        for (let i = 0; i < movies.length; i++) {
            if (movies[i].id === id) {
                return movies[i];
            }
        }

        return null;
    };

    const add = function (movie) {
        movie.id = nextId();
        let movies = dbConnection.loadFiles();
        movies.push(movie);
        dbConnection.saveChanges(movies);
    };

    const nextId = function () {
        return dbConnection.loadFiles().length + 1;
    };

    return {
        getAll,
        getById,
        add
    };
})();

module.exports = database;