function solve(input) {
    let delimeter = input.pop();

    return input.join(delimeter);
}

let result = solve(['One', 
    'Two', 
    'Three', 
    'Four', 
    'Five', 
    '-']);

console.log(result);