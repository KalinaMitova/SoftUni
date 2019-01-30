const mongoose = require('mongoose');
const { Schema } = mongoose;
const encryprion = require('../utilities/encryption');

const requiredPropertyErrorMessage = '{0} is required.';
const invalidAgeErrorMessage = 'Age must be between 0 and 120';
const invalidGenderErrorMessage = 'Gender should be either "Male" or "Female".';

let userSchema = mongoose.Schema({
    username: {
        type: Schema.Types.String,
        required: getErrorMessage('Username'),
        unique: true,
    },
    password: {
        type: Schema.Types.String,
        required: getErrorMessage('Password'),
    },
    salt: {
        type: Schema.Types.String,
        require: true,
    },
    firstName: {
        type: Schema.Types.String,
        required: getErrorMessage('First name'),
    },
    lastName: {
        type: Schema.Types.String,
        required: getErrorMessage('Last name'),
    },
    age: {
        type: Schema.Types.Number,
        min: [0, invalidAgeErrorMessage],
        max: [120, invalidAgeErrorMessage]
    },
    gender: {
        type: Schema.Types.String,
        enum: {
            values: ['Male', 'Female'],
            message: invalidGenderErrorMessage
        }
    },
    roles: [{
        type: Schema.Types.String
    }],
    boughtProducts: [{
        type: Schema.Types.ObjectId,
        ref: 'Product'
    }],
    createdProducts: [{
        type: Schema.Types.ObjectId,
        ref: 'Product'
    }],
    createdCategories: [{
        type: Schema.Types.ObjectId,
        ref: 'Category'
    }],
});

userSchema.method({
    authenticate: function(password) {
        let hashedPassword = encryprion.generateHashedPassword(this.salt, password);

        return hashedPassword === this.password;
    }
});

function getErrorMessage(propertyName) {
    return requiredPropertyErrorMessage.replace('{0}', propertyName);
}

const User = mongoose.model('User', userSchema);

module.exports = User;

module.exports.seedAdminUser = () => {
    User.findOne({username: 'admin'})
        .then((user) => {
            if(!user) {
                let salt = encryprion.generateSalt();
                let hashedPass = encryprion.generateHashedPassword(salt, 'admin12');

                User.create({
                    username: 'admin',
                    firstName: 'Chuck',
                    lastName: 'Norris',
                    salt,
                    password: hashedPass,
                    age: 56,
                    gender: 'Male',
                    roles: ['Admin']
                });
            }
        })
        .catch(err => console.log);
};