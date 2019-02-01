const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const encryption = require('../util/encryption');

const userSchema = new mongoose.Schema({
    username: {
        type: Schema.Types.String,
        required: true,
        unique: true
    },
    hashedPass: {
        type: Schema.Types.String,
        required: true
    },
    firstName: {
        type: Schema.Types.String
    },
    lastName: {
        type: Schema.Types.String
    },
    salt: {
        type: Schema.Types.String,
        required: true
    },
    roles: [{
        type: Schema.Types.String,
    }],
    rents: [{
        type: Schema.Types.ObjectId,
        ref: 'Rent'
    }]
});

userSchema.method({
    authenticate: function (password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashedPass;
    }
});

const User = mongoose.model('User', userSchema);

User.seedAdminUser = async () => {
    try {
        let users = await User.find({});

        if (users.length > 0) {
            return;
        }

        const salt = encryption.generateSalt();
        const hashedPass = encryption.generateHashedPassword(salt, "admin12");

        return User.create({
            username: "admin",
            hashedPass: hashedPass,
            salt: salt,
            roles: ["Admin"],
            firstName: "Dimitar",
            lastName: "Ruskov",
        });
    } catch (err) {
        console.log(err);
    }
};

module.exports = User;