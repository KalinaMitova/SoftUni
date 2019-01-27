function solve(input) {
    let k = +input.shift();
    
    let firstElements = [];
    let lastElements = [];

    let length = input.length;
    let lastElementStartPoint = length - k < 0 ? 0 : length - k;

    for (let i = 0; i < k; i++) {
        let lastElementsIndex = lastElementStartPoint + i;

        firstElements.push(input[i]);
        lastElements.push(input[lastElementsIndex]);
    }

    console.log(firstElements.join(" "));
    console.log(lastElements.join(" "));
}

solve([3, 8, 9]);