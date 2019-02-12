const Thread = require('../models/Thread');
const User = require('../models/User');

module.exports = {
    index: async (req, res) => {
        try {
            let data = {};

            if (req.user) {

                const isAdmin = req.user.roles.includes('Admin');

                if (isAdmin) {
                    let threads = await Thread.find({});

                    for (const thread of threads) {
                        thread.usernames = [];

                        for (let i = 0; i < thread.users.length; i++) {
                            const userId = thread.users[i];
                            let user = await User.findById(userId);
                            thread.usernames.push(user.username);
                        }

                        thread.usernames = thread.usernames.join(" ");
                    }

                    data.threads = threads;
                }
            }

            res.render('home/index', data);
        } catch (err) {
            // TODO: show error
            res.redirect('/');
            return;
        }
    }
};