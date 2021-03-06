function solve(input) {
    let register = new Map();

    input.forEach((element) => {
        let [town, product, price] = element.split(" | ");
        
        if(!register.has(product)) {
            register.set(product, new Map());
        }

        register.get(product).set(town, price);
    });

    register.forEach((product, key) => {
        let lowestPrice = [...product]
            .reduce((a, b) => {
                if(+a[1] > +b[1]) {
                    return b;
                } else if (+a[1] < +b[1]) {
                    return a;
                }

                return a;
            }); 

        console.log(`${key} -> ${lowestPrice[1]} (${lowestPrice[0]})`);
    });
}

solve(["Sofia City | Audi | 100000",
    "Sofia City | BMW | 100000",
    "Sofia City | Mitsubishi | 10000",
    "Sofia City | Mercedes | 10000",
    "Sofia City | NoOffenseToCarLovers | 0",
    "Mexico City | Audi | 1000",
    "Mexico City | BMW | 99999",
    "New York City | Mitsubishi | 10000",
    "New York City | Mitsubishi | 1000",
    "Mexico City | Audi | 100000",
    "Washington City | Mercedes | 1000"]);