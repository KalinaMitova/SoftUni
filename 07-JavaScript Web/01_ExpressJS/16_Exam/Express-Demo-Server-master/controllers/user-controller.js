const encryption = require('../util/encryption');
const notify = require('../common/notificationHandler');

const User = require('mongoose').model('User');
const Project = require('../models/Project');
const Team = require('../models/Team');

module.exports = {
    registerGet: (req, res) => {
        res.render('users/register');
    },
    registerPost: async (req, res) => {
        const reqUser = req.body;
        const salt = encryption.generateSalt();
        const hashedPass =
            encryption.generateHashedPassword(salt, reqUser.password);
        try {
            const errorMessage = validateUser(reqUser);
            if (errorMessage) {
                notify.showError(res, errorMessage, reqUser, 'users/register');
                return;
            }

            let user = await User.findOne({
                username: reqUser.username
            });

            if (user) {
                notify.showError(res, 'Username is already exist.', reqUser, 'users/register');
                return;
            }

            const newUser = new User({
                username: reqUser.username,
                hashedPass,
                salt,
                firstName: reqUser.firstName,
                lastName: reqUser.lastName,
                roles: ['User']
            });

            if (reqUser.profilePictureUrl.length !== 0) {
                newUser.profilePictureUrl = reqUser.profilePictureUrl;
            }

            newUser.save();

            req.logIn(newUser, (err, user) => {
                if (err) {
                    notify.showError(res, err, user, 'users/register');
                } else {
                    res.redirect('/');
                }
            });
        } catch (e) {
            console.log(e);
            notify.showError(res, e, null, 'users/register');
        }
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    loginGet: (req, res) => {
        res.render('users/login');
    },
    loginPost: async (req, res) => {

        const reqUser = req.body;
        try {
            const user = await User.findOne({
                username: reqUser.username
            });
            if (!user) {
                errorHandler('Invalid user data');
                return;
            }
            if (!user.authenticate(reqUser.password)) {
                errorHandler('Invalid user data');
                return;
            }
            req.logIn(user, (err, user) => {
                if (err) {
                    errorHandler(err);
                } else {
                    res.redirect('/');
                }
            });
        } catch (e) {
            errorHandler(e);
        }

        function errorHandler(e) {
            console.log(e);
            notify.showError(res, e, null, 'users/login');
        }
    },
    projectsGet: async (req, res) => {
        try {
            const searchKeyword = req.query.searchKeyword;
            const condition = {};

            if (searchKeyword) {
                condition.name = {
                    $regex: new RegExp(`${searchKeyword}`),
                    $options: 'i',
                };
            }

            let projects = await Project.find(condition)
                .populate('team');

            res.render('users/projects-user', {
                projects,
                searchKeyword,
            });
        } catch (error) {
            notify.showError(res, `Something went wrong!`, null, 'home/index');
        }
    },
    teamsGet: async (req, res) => {
        try {
            const searchKeyword = req.query.searchKeyword;
            const condition = {};

            if (searchKeyword) {
                condition.name = {
                    $regex: new RegExp(`${searchKeyword}`),
                    $options: 'i',
                };
            }

            let teams = await Team.find(condition)
                .populate('members')
                .populate('projects');

            res.render('users/teams-user', {
                teams,
                searchKeyword,
            });
        } catch (error) {
            notify.showError(res, `Something went wrong!`, null, 'home/index');
        }
    },
    profileGet: async (req, res) => {
        res.render('users/profile', await getProfileData(req.user))
    },
    leaveTeamPost: async (req, res) => {
        try {
            const teamId = req.params.teamId;

            const indexOfTeam = req.user.teams.indexOf(teamId);

            if (indexOfTeam < 0) {
                notify.showError(res, `You are not a member of this team!`, await getProfileData(req.user), 'users/profile');
                return;
            }

            const team = await Team.findById(teamId);
            if (!team) {
                notify.showError(res, `Team not found!`, await getProfileData(req.user), 'users/profile');
                return;
            }

            const indexOfMember = team.members.indexOf(req.user._id);
            if (indexOfMember < 0) {
                notify.showError(res, `This member is not a part of the team!`, await getProfileData(req.user), 'users/profile');
                return;
            }

            team.members.splice(indexOfMember, 1);
            team.save();

            req.user.teams.splice(indexOfTeam, 1);
            req.user.save();

            res.redirect('/user/profile');
        } catch (error) {
            notify.showError(res, `Something went wrong!`, null, 'home/index');
        }
    },
};

async function getProfileData(user) {
    const teams = await Team.find({
        members: user._id
    });

    const projects = await Project.find({
        team: {
            $in: user.teams
        }
    });

    return {
        profilePictureUrl: user.profilePictureUrl,
        teams,
        projects
    };
}

function validateUser(user) {
    if (user.username.length === 0) {
        return 'Username is required';
    } else if (user.password.length === 0) {
        return 'Password is required';
    } else if (user.firstName.length === 0) {
        return 'First name is required';
    } else if (user.lastName.length === 0) {
        return 'Last name is required';
    }

    return null;
}