function solve(matrix) {

    let isMagical = true;
    let firstRowSum = matrix[0].reduce((a, b) => a + b);

    matrix.forEach((row, rowIndex) => {
        let rowSum = row.reduce((a, b) => a + b);
        let colSum = matrix
            .map((item, index) => {
                return matrix[index][rowIndex];
            })
            .reduce((a, b) => a + b); 

        if(rowSum !== firstRowSum || colSum !== firstRowSum) {
            isMagical = false;
        }
    });

    return isMagical;
}

let result = solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]);

console.log(result);