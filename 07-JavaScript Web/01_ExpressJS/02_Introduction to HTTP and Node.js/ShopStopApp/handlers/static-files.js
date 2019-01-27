const fs = require('fs');
const path = require('path');
const url = require('url');

function getContentType(url) {
    const tokens = url.split('.');
    const extension = tokens[tokens.length - 1];
    let type;

    switch (extension) {
        case 'html':
        case 'css':
            type = 'text';
            break;
        case 'jpeg':
        case 'png':
            type = "image";
            break;
        case 'mpeg':
        case 'ogg':
            type = "audio";
            break;
        case 'mp4':
            type = "video";
            break;
        case 'json':
            type = "application";
            break;
    }

    if (type) {
        return `${type}/${extension}`;
    } else {
        return null;
    }
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname.startsWith('/content/') && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, `..${req.pathname}`)
        );

        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('Resource not found!');
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