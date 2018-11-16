function sort(arrOfNumbers, sortArgument) {
    
    let asc = function(a, b) {
        return a - b;
    }

    let desc = function(a, b) {
        return b - a;     
    }

    let sortingStrategies = {
        asc,
        desc
    };

    return arrOfNumbers.sort(sortingStrategies[sortArgument]);
}

console.log(sort([14, 7, 17, 6, 8], 'asc'));