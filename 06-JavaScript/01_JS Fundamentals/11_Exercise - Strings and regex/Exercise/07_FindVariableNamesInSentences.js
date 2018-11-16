function solve(input) {
    let pattern = /\b_([A-Za-z0-9]+)\b/g;
    let re = RegExp(pattern);
    let m; 
    let names = [];

    do {
        m = re.exec(input);
        if(m) {
            names.push(m[1]);
        }
    } while(m)

    return names.join(",");
}

let result = solve('The _id and _age variables are both integers.');
console.log(result);