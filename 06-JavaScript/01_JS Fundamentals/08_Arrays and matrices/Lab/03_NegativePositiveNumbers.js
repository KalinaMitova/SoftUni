function solve(input) {
    let newArray = [];

    for (let i = 0; i < input.length; i++) {
        let element = input[i];
        
        if(element >= 0) {
            newArray.push(element);
        }
        else {
            newArray.unshift(element);
        }
    }
    
    for (const element of newArray) {
        console.log(element);
    }
}

solve([3, -2, 0, -1]);