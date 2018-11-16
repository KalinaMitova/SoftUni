function solve(input) {
    input.sort((a, b) => a - b);

    let twoSmallest = [];
    for (let i = 0; i < 2; i++) {
        twoSmallest.push(input[i]);
    }

    console.log(twoSmallest.join(" "));
}

solve([-5, 5 , 10, 0, -1]);