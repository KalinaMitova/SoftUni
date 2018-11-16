function solve(input) {
    let biggest = input[0][0];

    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[row].length; col++) {
            let element = input[row][col];
            
            if(biggest < element) {
                biggest = element;
            }
        }        
    }

    return biggest;
}

console.log(solve([[20, 50, 10],
                    [8, 33, 145]]));