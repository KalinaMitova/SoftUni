function solve(input) {
    let width = +input[0];
    let height = +input[1];
    let x = +input[2];
    let y = +input[3];

    let matrix = [];
    for (let row = 0; row < height; row++) {
        matrix[row] = [];
        for (let col = 0; col < width; col++) {
            let number = Math.max(Math.abs(x - row), Math.abs(y - col));
            matrix[row][col] = number + 1;
        }        
    }

    matrix.forEach((item) => {
        console.log(item.join(" "))
    });
}

solve([3, 3, 2, 2]);