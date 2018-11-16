function solve(input) {
    let objects = [];
    input.shift();
    input.forEach((element) => {
            let [town, latitude, longitude] = element.split(/ *\| */).filter(e => e);
            
            let obj = {
                "Town": town,
                "Latitude": +latitude,
                "Longitude": +longitude
            };

            let str = JSON.stringify(obj);

            objects.push(str);
        });
    
    return "[" + objects.toString() + "]";
}

let result = solve(['| Town | Latitude | Longitude |',
'| Veliko Tarnovo | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);

console.log(result);