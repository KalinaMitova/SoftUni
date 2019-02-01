const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const rentSchema = new Schema({
    days: {
        type: Schema.Types.Number,
        required: true
    },
    car: {
        type: Schema.Types.ObjectId,
        ref: 'Car',
        required: true,
    },
    tenant: {
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true,
    },
});

module.exports = mongoose.model('Rent', rentSchema);