const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const messageSchema = new Schema({
    content: {
        type: Schema.Types.String,
        required: true,
    },
    userReceiver: {
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true,
    },
    thread: {
        type: Schema.Types.ObjectId,
        ref: 'Thread',
        required: true,
    },
});

module.exports = mongoose.model('Message', messageSchema);