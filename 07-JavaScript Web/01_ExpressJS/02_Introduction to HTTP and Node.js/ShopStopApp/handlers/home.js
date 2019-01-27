const url = require('url');
const fs = require('fs');
const qs = require('querystring');
const path = require('path');
const Product = require('../models/Product');

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname === '/' && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, '../views/home/index.html')
        );

        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('404 Not found!');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-type': 'text/html'
            });

            let queryData = qs.parse(url.parse(req.url).query);

            Product.find({})
                .then((products) => {
                    if (queryData.query) {
                        products = products.filter((p) => {
                            return p.name.toLowerCase().includes(queryData.query.toLowerCase());
                        });
                    }

                    let content = "";
                    for (const product of products) {
                        content +=
                            `<div class="product-card">
                                <img src="${product.image}" class="product-img"/>
                                <h2>${product.name}</h2>
                                <p>${product.description}</p>
                            </div>`;
                    }

                    const html = data.toString().replace('{content}', content);

                    res.write(html);
                    res.end();
                });
        });
    } else {
        return true;
    }
};