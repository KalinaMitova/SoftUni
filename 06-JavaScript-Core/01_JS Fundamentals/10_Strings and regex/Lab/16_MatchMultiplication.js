function solve(input) {
    let pattern = /(-?\d+)\s*\*\s*(-?\d+(?:.\d+)?)/g;

    let result = input.replace(pattern, function(m, g1, g2) {
        return +g1 * +g2;
    });

    return result;
}

solve('My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).');