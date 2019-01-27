function solve(input) {
    let register = {};
    input.forEach(element => {
        let [town, population] = element.split(" <-> ");

        if(register[town] === undefined) {
            register[town] = 0;
        }

        register[town] += +population;
    });

    Object.keys(register).forEach((key) => {
        console.log((`${key} : ${register[key]}`))
    });
}

let result = solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);