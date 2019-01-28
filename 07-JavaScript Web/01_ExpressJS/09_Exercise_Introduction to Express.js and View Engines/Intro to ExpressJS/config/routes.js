module.exports = app => {
    app.get('/', (req, res) => {
        res.write('Hello World!');
        res.end();
    });
};