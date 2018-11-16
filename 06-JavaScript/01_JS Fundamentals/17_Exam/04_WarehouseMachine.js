function solve(input) {
    let warehouse = {
        brands: {},
        in: function(tokens) {
            let coffeeBrand = tokens[0];
            let coffeeName = tokens[1];
            let expireDate = tokens[2];
            let quantity = +tokens[3];

            if(!this.brands.hasOwnProperty(coffeeBrand)) {
                this.brands[coffeeBrand] = {};
            }

            if(!this.brands[coffeeBrand].hasOwnProperty(coffeeName)) {
                this.brands[coffeeBrand][coffeeName] = {
                    name: coffeeName,
                    expireDate: expireDate,
                    quantity: quantity
                };
            } else {
                let currentBrand = this.brands[coffeeBrand][coffeeName];
                if(currentBrand.expireDate < expireDate) {
                    currentBrand.expireDate = expireDate;
                    currentBrand.quantity = quantity;
                } else if (currentBrand.expireDate === expireDate) {
                    currentBrand.quantity += quantity;
                }
            }
        },
        out: function(tokens) {
            let coffeeBrand = tokens[0];
            let coffeeName = tokens[1];
            let expireDate = tokens[2];
            let quantity = +tokens[3];

            if(this.brands.hasOwnProperty(coffeeBrand) && 
                this.brands[coffeeBrand].hasOwnProperty(coffeeName)) {

                let brand = this.brands[coffeeBrand][coffeeName];
                if(brand.expireDate > expireDate && brand.quantity >= quantity) {
                    brand.quantity -= quantity;
                }
            }
        },
        report: function() {
            console.log('>>>>> REPORT! <<<<<')
            let brandsKeys = Object.keys(this.brands);
            brandsKeys.forEach((brand) => {
                console.log(`Brand: ${brand}:`)
                let coffeeKey = Object.keys(this.brands[brand]);
                coffeeKey.forEach((coffeeKey) => {
                    let coffee = this.brands[brand][coffeeKey];
                    console.log(`-> ${coffee.name} -> ${coffee.expireDate} -> ${coffee.quantity}.`)
                });
            });
        },
        inspection: function() {
            console.log('>>>>> INSPECTION! <<<<<');
            Object.keys(this.brands)
                .sort((a, b) => a.localeCompare(b))            
                .forEach((brand) => {
                    console.log(`Brand: ${brand}:`)
                    Object.keys(this.brands[brand])
                    .sort((a, b) => this.brands[brand][b].quantity - this.brands[brand][a].quantity)
                    .forEach((coffeeKey) => {
                        let coffee = this.brands[brand][coffeeKey];
                        console.log(`-> ${coffee.name} -> ${coffee.expireDate} -> ${coffee.quantity}.`)
                    });
                });
        }
    };

    input.forEach((element) => {
        let tokens = element.split(", ")
            .filter(e => e)
            .map(e => e.trim());

        let command = tokens
            .shift()
            .toLowerCase();

        warehouse[command](tokens);
    });
}

solve(["IN, Batdorf & Bronson, Espresso, 2025-05-25, 20",
    "IN, Folgers, Black Silk, 2023-03-01, 14",
    "IN, Lavazza, Crema e Gusto, 2023-05-01, 5",
    "IN, Lavazza, Crema e Gusto, 2023-05-02, 5",
    "IN, Folgers, Black Silk, 2022-01-01, 10",
    "IN, Lavazza, Intenso, 2022-07-19, 20",
    "OUT, Dallmayr, Espresso, 2022-07-19, 5",
    "OUT, Dallmayr, Crema, 2022-07-19, 5",
    "OUT, Lavazza, Crema e Gusto, 2020-01-28, 2",
    "REPORT",
    "INSPECTION",]);