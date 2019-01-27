function solve(input) {
    let data = [];
    
    input.forEach((element) => {
        let tokens = element.split(" / ");
        let name = tokens[0];
        let level = +tokens[1];

        let hero = {
            name: name,
            level: level,
            items: []
        };

        if(tokens[2] !== undefined) {
            let items = tokens[2].split(", ");
            hero.items = items;
        }

        data.push(hero);
    });

    return JSON.stringify(data);
}

let result = solve(['Isacc / 25',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara']);

console.log(result);