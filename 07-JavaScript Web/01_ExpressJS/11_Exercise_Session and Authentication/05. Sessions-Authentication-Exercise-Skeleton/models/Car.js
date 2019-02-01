const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const carSchema = new Schema({
    model: {
        type: Schema.Types.String,
        required: true,
    },
    imageUrl: {
        type: Schema.Types.String,
        required: true,
    },
    pricePerDay: {
        type: Schema.Types.Number,
        required: true,
    },
    isRented: {
        type: Schema.Types.Boolean,
        required: true,
        default: false,
    },
    rents: [{
        type: Schema.Types.ObjectId,
        ref: 'Rent'
    }]
});

module.exports = mongoose.model('Car', carSchema);