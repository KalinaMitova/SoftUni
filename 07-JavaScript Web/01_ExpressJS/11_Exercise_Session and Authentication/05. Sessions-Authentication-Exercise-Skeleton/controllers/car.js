const mongoose = require('mongoose');
const Car = mongoose.model('Car');
const Rent = mongoose.model('Rent');

const homePage = 'home/index';
const carAddPage = 'car/add';
const carAllPage = 'car/all';
const carEditPage = 'car/edit';
const rentCarPage = 'car/rent';

module.exports = {
    addGet: (req, res) => {
        res.render(carAddPage);
    },
    addPost: async (req, res) => {
        let carModel = req.body;

        try {
            if (!carModel.model || !carModel.imageUrl || !carModel.pricePerDay) {
                carModel.error = "All fields are required.";
                res.render(carAddPage, carModel);
                return;
            }

            await Car.create(carModel);

            res.redirect('/car/all');
        } catch (error) {
            carModel.error = "Something went wrong while adding a new car.";
            res.render(carAddPage, carModel);
        }
    },
    allGet: async (req, res) => {
        try {
            let condition = {
                isRented: false
            };

            let model = req.query.model;
            if (model) {
                condition.model = new RegExp(model.toLowerCase(), 'i');
            }

            let cars = await Car.find(condition);

            res.render(carAllPage, {
                cars
            });
        } catch (error) {
            res.render(homePage, {
                error: "Something went wrong."
            });
        }
    },
    rentGet: async (req, res) => {
        const carId = req.params.id;

        try {
            let car = await Car.findById(carId);

            if (!car) {
                res.render(homePage, {
                    error: "Car not found."
                });
                return;
            }

            res.render(rentCarPage, car);
        } catch (error) {
            res.render(homePage, {
                error: "Something went wrong."
            });
        }
    },
    rentPost: async (req, res) => {
        const carId = req.params.id;
        const days = req.body.days;

        if (!days || days < 1) {
            res.render(homePage, {
                error: "You can not rent a car for less than one day."
            });
            return;
        }

        try {
            let car = await Car.findById(carId);

            if (!car) {
                res.render(homePage, {
                    error: "Car not found."
                });
                return;
            }

            if (car.isRented) {
                res.render(homePage, {
                    error: "Car is already rented."
                });
                return;
            }

            let createdRent = await Rent.create({
                days,
                car: carId,
                tenant: req.user._id
            });

            await createdRent
                .populate('car', (err, rent) => {
                    if (err) {
                        throw err;
                    }

                    rent.car.rents.push(createdRent._id);
                    rent.car.isRented = true;
                    rent.car.save();
                })
                .populate('tenant', (err, rent) => {
                    if (err) {
                        throw err;
                    }

                    rent.tenant.rents.push(createdRent._id);
                    rent.tenant.save();
                });

            res.render('home/index', {
                success: "Car is rented successfuly."
            });
        } catch (error) {
            res.render(homePage, {
                error: "Something went wrong."
            });
        }
    },
    editGet: async (req, res) => {
        const carId = req.params.id;

        const car = await Car.findById(carId);

        res.render(carEditPage, car);
    },
    editPost: async (req, res) => {
        const carId = req.params.id;
        const carModel = req.body;

        try {
            if (!carModel.model || !carModel.imageUrl || !carModel.pricePerDay) {
                carModel.error = "All fields are required.";
                res.render(carAddPage, carModel);
                return;
            }

            const car = await Car.findByIdAndUpdate(carId, carModel);

            res.render(homePage, {
                success: "Car is updated successfully"
            });
        } catch (error) {
            res.render(homePage, {
                error: "Something went wrong."
            });
        }
    }
};