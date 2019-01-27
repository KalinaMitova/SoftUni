function solve(input) {
    let maxNumber = Number.MIN_SAFE_INTEGER;

    (function(input) {
        input.forEach((element) => {
            if(element > maxNumber) {
                maxNumber = element;
            }
        });
    })(input);

    return maxNumber;
}

console.log(solve([-3, -1, -34, -8, -50]));