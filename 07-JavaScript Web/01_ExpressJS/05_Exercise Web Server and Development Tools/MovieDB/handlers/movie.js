const fs = require('fs');
const db = require('../config/database.js');
const qs = require('querystring');

const handler = function (req, res) {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.method === 'GET') {
        if (req.pathname === '/movies/all') {
            fs.readFile('./views/viewAll.html', (err, data) => {
                if (err) {
                    console.log(err);
                    res.writeHead(500, {
                        'Content-Type': 'text/html'
                    });

                    res.write('Server error!');
                    res.end();
                    return;
                }

                const movies = db.getAll()
                    .map((movie) => {
                        return `<div class="movie">
                            <a href="/movies/details/${movie.id}" >
                            <img class="moviePoster" src="${movie.moviePoster}" />
                            </a>
                        </div>`;
                    })
                    .join("");

                const html = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', movies);

                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });

                res.write(html);
                res.end();
            });
        } else if (req.pathname === '/movies/add') {
            fs.readFile('./views/addMovie.html', (err, data) => {
                if (err) {
                    console.log(err);
                    res.writeHead(500, {
                        'Content-Type': 'text/html'
                    });

                    res.write('Server error!');
                    res.end();
                    return;
                }

                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });

                res.write(data);
                res.end();
            });
        } else if (req.pathname.startsWith('/movies/details/')) {
            fs.readFile('./views/details.html', (err, data) => {
                if (err) {
                    console.log(err);
                    res.writeHead(500, {
                        'Content-Type': 'text/html'
                    });

                    res.write('Server error!');
                    res.end();
                    return;
                }

                let pathnameParts = req.pathname.split('/');
                let id = pathnameParts[pathnameParts.length - 1];

                let movie = db.getById(Number.parseInt(id));

                if (!movie) {
                    res.writeHead(302, {
                        'Location': '/'
                    });

                    res.end();
                    return;
                }

                data = data.toString().replace(
                    '<div id="replaceMe">{{replaceMe}}</div>',
                    `<div class="content">
                    <img src="${movie.moviePoster}" alt="" />
                    <h3>Title ${movie.movieTitle}</h3>
                    <h3>Year ${movie.movieYear}</h3>
                    <p> ${movie.movieDescription}</p>
                  </div>`);

                res.writeHead(200, {
                    'Content-Type': 'text/html'
                });

                res.write(data);
                res.end();
            });
        } else {
            return true;
        }

    } else if (req.method === 'POST') {
        if (req.pathname === '/movies/add') {
            var body = '';

            req.on('data', function (data) {
                body += data;

                if (body.length > 1e6) {
                    req.connection.destroy();
                }
            });

            req.on('end', function () {
                var formData = qs.parse(body);

                fs.readFile('./views/addMovie.html', (err, data) => {
                    if (err) {
                        console.log(err);
                        res.writeHead(500, {
                            'Content-Type': 'text/html'
                        });

                        res.write('Server error!');
                        res.end();
                        return;
                    }

                    if (!formData.moviePoster || !formData.movieTitle) {

                        data = data.toString().replace(
                            '<div id="replaceMe">{{replaceMe}}</div>',
                            `<div id="errBox">
                                    <h2 id="errMsg">Please fill all fields</h2> 
                                </div>`);

                        res.writeHead(400, {
                            'Content-Type': 'text/html'
                        });

                        res.write(data);
                        res.end();

                        return;
                    }

                    db.add(formData);

                    data = data.toString().replace(
                        '<div id="replaceMe">{{replaceMe}}</div>',
                        `<div id="succssesBox">
                            <h2 id="succssesMsg">Movie Added</h2> 
                        </div>`);

                    res.writeHead(200, {
                        'Content-Type': 'text/html'
                    });
                    res.write(data);
                    res.end();
                });
            });
        }
    } else {
        return true;
    }
};

module.exports = handler;