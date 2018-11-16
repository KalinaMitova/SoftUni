function solve(number) {

    number += "";
    while (average(number) <= 5) {
        number += "9";
    }

    return number;

    function average(number) {
        let sum = 0;
        for (let i = 0; i < number.length; i++) {
            let digit = +number[i];
            sum += digit;
        }

        return sum / number.length;
    }
}

console.log(solve(5835));