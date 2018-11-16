function solve(input) {

    let doubledNumbers = [];

    let length = input.length;    
    for (let i = 1; i < length; i+=2) {
        let element = +input[i];
        
        doubledNumbers.push(element * 2);
    }

    return doubledNumbers.reverse().join(" ");
}

console.log(solve([10, 15, 20, 25]));