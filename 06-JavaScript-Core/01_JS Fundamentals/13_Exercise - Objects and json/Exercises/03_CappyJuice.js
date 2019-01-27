function solve(input) {
    let juices = {};
    let bottles = {};

    input.forEach((juiceData) => {
        let juiceQuantity = juiceData.split(" => ");

        let juice = juiceQuantity[0];
        let quantity = +juiceQuantity[1];

        if(juices[juice] === undefined) {
            juices[juice] = 0;
        }

        juices[juice] += quantity;

        if(juices[juice] >= 1000) {
            bottles[juice] = juices[juice];
        }
    });

    let keys = Object.keys(bottles);
    keys.forEach((juice) => {
        console.log(`${juice} => ${Math.floor(bottles[juice] / 1000)}`);        
    });
}

let result = solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);
