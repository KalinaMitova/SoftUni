function solve(input) {
    let obj = {};
    for (let i = 0; i < input.length; i+=2) {
        if(obj[input[i]] === undefined) {
            obj[input[i]] = 0;
        }
        
        obj[input[i]] += +input[i + 1];
    }

    return JSON.stringify(obj);
}

let result = solve(["Sofia", 20, "Varna", 3, "Sofia", 5, "Varna", 4]);

console.log(result);