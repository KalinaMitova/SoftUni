function solve(input) {

    let x1 = +input[0];
    let y1 = +input[1];
    let x2 = +input[2];
    let y2 = +input[3];

    console.log(comparsion(x1, y1, 0, 0));
    console.log(comparsion(x2, y2, 0, 0));
    console.log(comparsion(x1, y1, x2, y2));

    function comparsion(x1, y1, x2, y2) {
        let sideA = Math.abs(x1 - x2);
        let sideB = Math.abs(y1 - y2);

        let result = Math.sqrt(Math.pow(sideA, 2) + Math.pow(sideB, 2));

        if(result === parseInt(result)) {
            return `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`;
        }

        return `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`;
    }
}

solve([2, 1, 1, 1]);