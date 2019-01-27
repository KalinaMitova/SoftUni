function solve(input) {
    return input
        .join("")
        .split("")
        .reverse()
        .join("");
}

let result = solve(['I', 'am', 'student']);

console.log(result);