const mongoose = require('mongoose');
const Article = require('../models/Article');

module.exports = {
  index: (req, res) => {

    Article.find({})
      .populate('author', 'fullName')
      .select('id title content')
      .then((articles) => {

        res.render('home/index', {
          articles
        });
      })
      .catch((err) => {
        res.locals.error = err.message;
        res.render('home/index');
      });
  }
}