function solve(input) {
    let rotationCount = +input.pop() % input.length;

    for (let index = 0; index < rotationCount; index++) {
        let lastElement = input.pop();
        input.unshift(lastElement);
    }

    return input.join(" ");
}

let result = solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
);
console.log(result);