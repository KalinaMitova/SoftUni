const url = require('url');
const fs = require('fs');
const path = require('path');

const getContentType = function (pathname) {
    let extension = pathname.split('.')[1];
    let mimeType;

    switch (extension) {
        case 'html':
        case 'htm':
            mimeType = "text/html";
            break;
        case 'css':
            mimeType = "text/css";
            break;
        case 'jpeg':
        case 'jpg':
            mimeType = "image/jpeg";
            break;
        case 'png':
            mimeType = "image/png";
            break;
        case 'ico':
            mimeType = "image/x-icon";
            break;
        case 'otf':
            mimeType = "font/otf";
            break;
        case 'ttf':
            mimeType = "font/ttf";
            break;
        case 'woff':
            mimeType = "font/woff";
            break;
        case 'woff2':
            mimeType = "font/woff2";
            break;
        case 'js':
            mimeType = "text/javascript";
            break;
        case 'json':
            mimeType = "application/json";
            break;

        default:
            mimeType = "text/plain";
            break;
    }

    return mimeType;
};

const handler = function (req, res) {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if ((req.pathname.startsWith('/public/') || req.pathname === '/favicon.ico') && req.method === 'GET') {
        let filePath;
        if (req.pathname === '/favicon.ico') {
            debugger;
            filePath = path.normalize(
                path.join(__dirname, `../public/images/favicon.ico`)
            );
        } else {
            filePath = path.normalize(
                path.join(__dirname, `..${req.pathname}`)
            );
        }

        if (!fs.existsSync(filePath)) {
            res.writeHead(404, {
                'Content-Type': 'text/plain'
            });
            res.write('Not found!');
            res.end();

            return;
        }

        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });
                res.write('Not found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': getContentType(req.pathname)
            });
            res.write(data);
            res.end();
        });
    } else {
        return true;
    }
};

module.exports = handler;