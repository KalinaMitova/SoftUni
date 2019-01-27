function solve(array) {
    let counter = 0;

    for (let row = 0; row < array.length; row++) {
        for (let col = 0; col < array[row].length; col++) {
            counter += searchForNeighbors(array, row, col);
        }
    }

    return counter;

    function searchForNeighbors(array, inputRow, inputCol) {
        let counter = 0;

        let element = array[inputRow][inputCol];        
        if(inputCol + 1 < array[inputRow].length) {
            let nextElement = array[inputRow][inputCol + 1];
            if (nextElement === element) {
                counter++;
            }
        }

        if(inputRow + 1 < array.length) {
            let downElement = array[inputRow + 1][inputCol];
            if(downElement === element) {
                counter++;
            }
        }
        
        return counter;
    }
}