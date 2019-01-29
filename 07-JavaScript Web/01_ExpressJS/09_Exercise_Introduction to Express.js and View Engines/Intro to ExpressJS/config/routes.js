module.exports = app => {

    // Home page
    app.get('/', (req, res) => {
        res.render('../views/index');
    });

    // About page
    app.get('/about', (req, res) => {
        res.render('../views/about');
    });

    // Create page
    app.get('/create', (req, res) => {
        res.render('../views/create');
    });

    app.post('/create', (req, res) => {
        // TODO: Implement functionality.
    });

    // Details page
    app.get('/details/:id', (req, res) => {
        // TODO: Implement functionality.
    });
};