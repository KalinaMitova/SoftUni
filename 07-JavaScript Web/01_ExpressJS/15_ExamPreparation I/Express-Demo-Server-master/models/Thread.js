const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const threadSchema = new Schema({
    users: [{
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true,
    }],
    dateCreated: {
        type: Schema.Types.Date,
        default: Date.now,
        required: true
    },
});

module.exports = mongoose.model('Thread', threadSchema);