function solve(input) {
    let register = {};

    input.forEach(element => {
        let [town, product, amountPrice] = element.split(" -> ");

        if(register[town] === undefined) {
            register[town] = {};
        }
        if(register[town][product] === undefined) {
            register[town][product] = 0;
        }
        let [amount, price] = amountPrice.split(" : ").map(e => +e);
        let totalPrice = amount * price;
        register[town][product] += totalPrice;
    });

    Object.keys(register).forEach(town => {
        console.log(`Town - ${town}`);
        Object.keys(register[town]).forEach(product => {
            console.log(`$$$${product} : ${register[town][product]}`);
        });
    }) 
}

solve(["Sofia -> Laptops HP -> 200 : 2000",
    "Sofia -> Raspberry -> 200000 : 1500",
    "Sofia -> Audi Q7 -> 200 : 100000",
    "Montana -> Portokals -> 200000 : 1",
    "Montana -> Qgodas -> 20000 : 0.2",
    "Montana -> Chereshas -> 1000 : 0.3"])
