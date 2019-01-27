const fs = require('fs');
const db = require('../config/database');

const handler = function (req, res) {
    debugger;
    let headerName = req.rawHeaders.filter((h) => h.toLowerCase() === 'statusheader')[0];

    if (headerName && req.headers[headerName.toLowerCase()].toLowerCase() === "full") {
        fs.readFile('./views/status.html', (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(500, {
                    'Content-Type': 'text/html'
                });

                res.write('Server error!');
                res.end();
                return;
            }

            let count = db.getAll().length;

            data = data.toString().replace('{{replaceMe}}',
                count);

            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            res.write(data);
            res.end();
        });
    } else {
        return true;
    }
};

module.exports = handler;