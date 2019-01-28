const config = require('./config/config');
const database = require('./config/database');
const express = require('express');
const exspressStartUp = require('./config/express');
const routes = require('./config/routes');

const env = process.env.NODE_ENV || 'development';

const configuration = config[env];
const app = express();

database(configuration);
exspressStartUp(app);
routes(app);

app.listen(configuration.port, function () {
    console.log(`Listening on port ${configuration.port}...`)
});