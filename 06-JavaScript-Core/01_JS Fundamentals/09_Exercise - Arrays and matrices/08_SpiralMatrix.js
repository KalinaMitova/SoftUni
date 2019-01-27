function solve(rows, cols) {
    
    // Initialize matrix
    let matrix = [];
    for (let row = 0; row < rows; row++) {
        if (matrix[row] === undefined) {
            matrix[row] = [];
        }
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = undefined;
        }   
    }

    // Initialize directions
    let directions = {
        right: {
            row: 0,
            col: 1
        },
        down: {
            row: 1,
            col: 0
        },
        left: {
            row: 0,
            col: -1
        },
        up: {
            row: -1,
            col: 0
        }
    };

    let row = 0;
    let col = 0;
    let counter = 1;
    let allSteps = rows * cols;
    let direction = "right";

    while(counter <= allSteps) {

        matrix[row][col] = counter;
        row += directions[direction].row;
        col += directions[direction].col;
        counter++;

        if(direction === "right") {
            if(col >= cols || matrix[row][col] !== undefined) {
                direction = "down";
                col--;
                row++;
            }
        } else if (direction === "left") {
            if(col < 0 || matrix[row][col] !== undefined) {
                direction = "up";
                col++;
                row--;
            }
        } else if (direction === "down") {
            if(row >= rows || matrix[row][col] !== undefined) {
                direction = "left";
                row--;
                col--;
            }
        } else if (direction === "up") {
            if(row < 0 || matrix[row][col] !== undefined) {
                direction = "right";
                row++;
                col++;
            }
        }
    }

    matrix.forEach((row) => {
        console.log(row.join(" "));
    });
}

solve(3, 3);