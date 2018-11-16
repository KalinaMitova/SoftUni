function solve(input) {
    let biggest = +input[0];
    input.forEach((item, index) => {
        if(+item >= biggest) {
            biggest = +item;
            console.log(biggest);
        }
    });
}

let result = solve([20, 
    3, 
    2, 
    15,
    6, 
    1]);