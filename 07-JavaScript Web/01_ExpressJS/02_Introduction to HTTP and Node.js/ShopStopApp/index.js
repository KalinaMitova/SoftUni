const port = 3000;
const config = require('./config/config');
const database = require('./config/database.config');
const express = require('express');

let app = express();
let environment = process.env.NODE_ENV || 'development';
let configuration = config[environment];

database(configuration);
require('./config/express')(app, configuration);
require('./config/routes')(app);
require('./config/passport')();

app.listen(port, () => {
    console.log('Server is listening on port ' + port);
});