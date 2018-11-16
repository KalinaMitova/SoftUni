function solve(matrix) {
    let diagonalsSum = matrix
        .reduce((acc, cur, index) => {

            let currRow = cur.split(" ").map(el => +el);
            
            acc[0] += currRow[index];
            acc[1] += currRow[currRow.length - 1 - index];

            return acc;
        }, [0, 0]);

    if (diagonalsSum[0] === diagonalsSum[1]) {
        matrix.forEach((item, index) => {
            let currRow = item
                .split(" ")
                .map((el, elIndex, arr) => {
                    if(elIndex !== index && elIndex !== arr.length - 1 - index) {
                        el = diagonalsSum[0];
                    }

                    return el;
                });

            console.log(currRow.join(" "));
        });
    } else {
        matrix.forEach((item) => {
            console.log(item);
        });
    }
}


solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']);