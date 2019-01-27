function solve(input) {
    let elements = [];
    for (let i = 0; i < input.length; i+=2) {
        elements.push(input[i]);        
    }

    return elements.join(" ");
}

console.log(solve(['20', '30', '40']));