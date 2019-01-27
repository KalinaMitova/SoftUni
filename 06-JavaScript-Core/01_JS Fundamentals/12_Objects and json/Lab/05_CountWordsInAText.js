function solve(input) {
    let pattern = /[\w]+/g;
    let words = input[0].match(pattern);
    let count = {};

    words.forEach(element => {
        if(count[element] === undefined) {
            count[element] = 0;
        }
        count[element]++;
    });

    return JSON.stringify(count);
}

let result = solve(["JS devs use Node.js for server-side JS.-- JS for devs"]);

console.log(result);