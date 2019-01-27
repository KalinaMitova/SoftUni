function solve() {
    let args = [...arguments];

    let types = {};

    args.forEach((arg) => {
        let type = typeof arg;

        console.log(`${type}: ${arg}`);

        if(!types.hasOwnProperty(type)) {
            types[type] = 0;
        }

        types[type] += 1;
    });

    Object.keys(types)
        .sort((a, b) => {
            return types[b] - types[a];
        })
        .forEach((key) => {
            console.log(`${key} = ${types[key]}`)
        })
}

solve({ name: 'bob'}, 3.333, 9.999);