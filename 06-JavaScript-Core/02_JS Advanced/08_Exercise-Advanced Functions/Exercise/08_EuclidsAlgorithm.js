function solve(a, b) {
    let min = Math.min(a, b);
    let max = Math.max(a, b);

    let res = null;
    do {
        res = max % min;
        if(res === 0) {
            break;
        }
        max = min;
        min = res;
    } while (true);

    return min;
}

solve(252, 105);

// Closure solution
function solve(a, b) {
    let solver = divisorFinder(a, b);

    let result;
    do {
        result = solver();
    } while(!result);

    return result;

    function divisorFinder(a, b) {
        let min = Math.min(a, b);
        let max = Math.max(a, b);
    
        let res = null;
    
        return function find() {
            res = max % min;
            if(res === 0) {
                return min;
            }
            max = min;
            min = res;
            return 0;
        };
    }
}