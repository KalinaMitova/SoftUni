const url = require('url');
const fs = require('fs');

const handler = function (req, res) {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname === '/' && req.method === 'GET') {
        fs.readFile('./views/home.html', (err, data) => {
            if (err) {
                console.log(err);
                return;
            }

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