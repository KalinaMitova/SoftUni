const mongoose = require('mongoose');
const encryption = require('../util/encryption');

const userSchema = new mongoose.Schema({
    username: {
        type: mongoose.Schema.Types.String,
        required: true,
        unique: true
    },
    hashedPass: {
        type: mongoose.Schema.Types.String,
        required: true
    },
    firstName: {
        type: mongoose.Schema.Types.String,
        required: true,
    },
    lastName: {
        type: mongoose.Schema.Types.String,
        required: true,
    },
    salt: {
        type: mongoose.Schema.Types.String,
        required: true
    },
    roles: [{
        type: mongoose.Schema.Types.String
    }],
    teams: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Team',
    }],
    profilePictureUrl: {
        type: mongoose.Schema.Types.String,
        default: 'https://t4.ftcdn.net/jpg/02/15/84/43/240_F_215844325_ttX9YiIIyeaR7Ne6EaLLjMAmy4GvPC69.jpg',
    },

});

userSchema.method({
    authenticate: function (password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashedPass;
    }
});

const User = mongoose.model('User', userSchema);

User.seedAdminUser = async () => {
    try {
        let users = await User.find();
        if (users.length > 0) return;
        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, 'Admin');
        return User.create({
            username: 'Admin',
            firstName: 'Admin',
            lastName: 'Adminov',
            salt,
            hashedPass,
            profilePictureUrl: 'http://profilepicturesdp.com/wp-content/uploads/2018/07/pics-for-profile-picture.jpg',
            roles: ['Admin']
        });
    } catch (e) {
        console.log(e);
    }
};

module.exports = User;