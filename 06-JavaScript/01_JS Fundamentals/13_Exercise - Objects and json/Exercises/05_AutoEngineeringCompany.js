function solve(input) {
    let vehicles = {};

    input.forEach((vehicle) => {
        let tokens = vehicle.split(" | ");
        let brand = tokens[0];
        let model = tokens[1];
        let producedCars = +tokens[2];

        if(vehicles[brand] === undefined) {
            vehicles[brand] = {};
        }

        if(vehicles[brand][model] === undefined) {
            vehicles[brand][model] = 0;
        }

        vehicles[brand][model] += producedCars;
    });

    let brands = Object.keys(vehicles);
    brands.forEach((brand) => {
        console.log(brand);

        let models = Object.keys(vehicles[brand]);
        models.forEach((model) => {
            console.log(`###${model} -> ${vehicles[brand][model]}`);
        });
    });
}

solve(['Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10']);