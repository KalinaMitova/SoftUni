const statusHandler = require('./status');
const homeHandler = require('./home');
const staticFilesHandler = require('./static-files');
const movieHandler = require('./movie');

module.exports = [
    statusHandler,
    homeHandler,
    movieHandler,
    staticFilesHandler,
];