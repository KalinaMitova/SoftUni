const notify = require('../common/notificationHandler');

const User = require('../models/User');
const Team = require('../models/Team');
const Project = require('../models/Project');

module.exports = {
    createTeamGet: async (req, res) => {
        res.render('admin/create-team');
    },
    createTeamPost: async (req, res) => {
        try {
            const name = req.body.name;
            if (!name) {
                notify.showError(res, "Name is required!", req.body, 'admin/create-team');
                return;
            }

            const team = await Team.create({
                name
            });

            if (!team) {
                notify.showError(res, "Something went wrong!", req.body, 'admin/create-team');
                return;
            }

            notify.showSuccess(res, `Team '${name}' created successfuly!`, null);
        } catch (error) {
            notify.showError(res, "Something went wrong!", req.body, 'admin/create-team');
        }
    },
    createProjectGet: async (req, res) => {
        res.render('admin/create-project');
    },
    createProjectPost: async (req, res) => {
        try {
            const name = req.body.name;
            if (!name) {
                notify.showError(res, "Name is required!", req.body, 'admin/create-project');
                return;
            }

            const description = req.body.description;
            if (!description) {
                notify.showError(res, "Description is required!", req.body, 'admin/create-project');
                return;
            }

            const project = await Project.create({
                name,
                description,
            });

            if (!project) {
                notify.showError(res, "Something went wrong!", req.body, 'admin/create-project');
                return;
            }

            notify.showSuccess(res, `Project '${name}' created successfuly!`, null);
        } catch (error) {
            notify.showError(res, "Something went wrong!", req.body, 'admin/create-project');
        }
    },
    projectDistributeGet: async (req, res) => {
        try {
            res.render('admin/projects-admin', await getTeamsAndProjects());
        } catch (error) {
            notify.showError(res, "Something went wrong!", null, 'admin/projects-admin');
        }
    },
    projectDistributePost: async (req, res) => {
        try {
            const teamId = req.body.teamId;
            const projectId = req.body.projectId;

            const team = await Team.findById(teamId);
            if (!team) {
                notify.showError(res, `Team not found!`, await getTeamsAndProjects(), 'admin/projects-admin');
                return;
            }

            const project = await Project.findById(projectId);
            if (!project) {
                notify.showError(res, `Project not found!`, await getTeamsAndProjects(), 'admin/projects-admin');
                return;
            }

            if (project.team) {
                notify.showError(res, `This project is already distributed!`, await getTeamsAndProjects(), 'admin/projects-admin');
                return;
            }

            team.projects.push(project._id);
            project.team = team._id;

            await team.save();
            await project.save();

            notify.showSuccess(res, `Team '${team.name}' is successfuly distributed to project '${project.name}'!`, null);
        } catch (error) {
            notify.showError(res, `Something went wrong!`, await getTeamsAndProjects(), 'admin/projects-admin');
        }
    },
    teamDistributeGet: async (req, res) => {
        try {
            res.render('admin/teams-admin', await getUsersAndTeams());
        } catch (error) {
            notify.showError(res, `Something went wrong!`, await getUsersAndTeams(), 'admin/teams-admin');
        }
    },
    teamDistributePost: async (req, res) => {
        try {
            const userId = req.body.userId;
            const teamId = req.body.teamId;

            const user = await User.findById(userId);
            if (!user) {
                notify.showError(res, `User not found!`, await getUsersAndTeams(), 'admin/teams-admin');
                return;
            }

            const team = await Team.findById(teamId);
            if (!team) {
                notify.showError(res, `Team not found!`, await getUsersAndTeams(), 'admin/teams-admin');
                return;
            }

            if (user.teams && user.teams.indexOf(team._id) > -1) {
                notify.showError(res, `This user is already member of this team!`, await getUsersAndTeams(), 'admin/teams-admin');
                return;
            }

            team.members.push(user._id);
            user.teams.push(team._id);

            await team.save();
            await user.save();

            notify.showSuccess(res, `User '${user.username}' is successfuly distributed to team '${team.name}'!`, null);
        } catch (error) {
            notify.showError(res, `Something went wrong!`, await getUsersAndTeams(), 'admin/teams-admin');
        }
    },
};

async function getTeamsAndProjects() {
    const teams = await Team.find({});
    const projects = await Project.find({
        team: {
            $exists: false
        }
    });

    return {
        teams,
        projects
    };
}

async function getUsersAndTeams() {
    const users = await User.find({});
    const teams = await Team.find({});

    return {
        users,
        teams
    };
}