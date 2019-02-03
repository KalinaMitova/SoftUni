const Article = require('../models/Article');
const User = require('../models/User');

const adminRole = 'Admin';

// Pages
const homePageRedirect = '/';
const articleCreate = 'article/create';
const articleEdit = 'article/edit';
const articleDelete = 'article/delete';
const articleDetails = 'article/details';

// Error messages
const requiredFields = "All fields are required.";
const somethingWentWrong = "Something went wrong.";

module.exports = {
    createGet: (req, res) => {
        res.render(articleCreate);
    },
    createPost: (req, res) => {
        const articleModel = req.body;

        if (!articleModel.title || !articleModel.content) {
            res.locals.error = requiredFields;
            res.render(articleCreate, articleModel);
            return;
        }

        const newArticle = new Article({
            title: articleModel.title,
            content: articleModel.content,
            author: req.user.id,
        });

        newArticle.save()
            .then((savedArticle) => {
                req.user.articles.push(savedArticle._id);
                req.user.save()
                    .then(() => {
                        res.redirect(homePageRedirect)
                    });
            })
            .catch(() => {
                res.locals.error = somethingWentWrong;
                res.render(articleCreate, articleModel);
            });
    },
    editGet: (req, res) => {
        const articleId = req.params.id;
        console.log(articleId);
        Article.findById(articleId)
            .select('title content')
            .then((article) => {
                if (!article) {
                    res.redirect(homePageRedirect);
                }

                res.render(articleEdit, article);
            })
            .catch((err) => {
                console.log(err);
                res.redirect(homePageRedirect);
            });
    },
    editPost: (req, res) => {
        const articleModel = req.body;

        if (!articleModel.title || !articleModel.content) {
            res.locals.error = requiredFields;
            res.render(articleEdit, articleModel);
            return;
        }

        const articleId = req.params.id;

        Article.findByIdAndUpdate(articleId, articleModel)
            .then(() => {
                res.redirect(homePageRedirect)
            })
            .catch(() => {

                res.locals.error = somethingWentWrong;
                res.render(articleEdit, articleModel);
            });
    },
    deleteGet: (req, res) => {
        const articleId = req.params.id;

        Article.findById(articleId)
            .select('title content')
            .then((article) => {
                if (!article) {
                    res.redirect(homePageRedirect);
                }

                res.render(articleDelete, article);
            })
            .catch((err) => {
                res.redirect(homePageRedirect);
            });
    },
    deletePost: (req, res) => {
        const articleId = req.params.id;

        Article.findByIdAndRemove(articleId)
            .then((article) => {
                User.update({
                        _id: article.author
                    }, {
                        $pull: {
                            articles: articleId
                        }
                    })
                    .then(() => {
                        res.redirect(homePageRedirect);
                    })
                    .catch(() => {
                        res.redirect(homePageRedirect);
                    });

            })
            .catch(() => {
                res.redirect(homePageRedirect);
            });
    },
    detailsGet: (req, res) => {
        const articleId = req.params.id;

        Article.findById(articleId)
            .populate('author', 'fullName')
            .then((article) => {
                if (!article) {
                    res.redirect(homePageRedirect);
                }

                let isAdminOrAuthor = req.user && (req.user.isInRole(adminRole) || req.user.isAuthor(article));

                res.render(articleDetails, {
                    article,
                    isAdminOrAuthor
                });
            })
            .catch((err) => {
                res.redirect(homePageRedirect);
            });
    },
};