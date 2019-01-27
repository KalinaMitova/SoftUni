function add(number) {
    let sum = 0;

    return (function solve(number) {
        solve.toString = function() {
            return sum;
        };

        sum += number;
        return solve;    
    })(number);    
};

console.log(add(1)(6)(-3));