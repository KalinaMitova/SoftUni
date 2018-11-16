function solve(input) {
    let products = {};

    input.forEach((productData) => {
        let tokens = productData.split(" : ");
        let name = tokens[0];
        let price = tokens[1];

        let product = [name, price];

        let groupName = name[0];

        if(products[groupName] === undefined) {
            products[groupName] = [];
        }

        products[groupName].push(product);
    });

    let productsKeys = Object.keys(products);
    productsKeys.sort((a, b) => {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });

    productsKeys.forEach((productGroup) => {
        console.log(productGroup);

        products[productGroup].sort((a, b) => {
            return a[0].toLowerCase().localeCompare(b[0].toLowerCase());
        });

        products[productGroup].forEach((product) => {
            console.log(`  ${product[0]}: ${product[1]}`);
        });
    });
}

solve(['Appricot : 20.4',
                    'Fridge : 1500',
                    'TV : 1499',
                    'Deodorant : 10',
                    'Boiler : 300',
                    'Apple : 1.25',
                    'Anti-Bug Spray : 15',
                    'T-Shirt : 10']);
