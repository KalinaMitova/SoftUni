function solve(input) {
    let products = [];
    let totalPrice = 0;

    input.forEach((element, index) => {
        if(index % 2 === 0) {
            products.push(input[index]);
        }
        else {
            totalPrice += + input[index];
        }
    });

    let output = `You purchased ${products.join(", ")} for a total sum of ${totalPrice}`;

    return output;
}

let result = solve(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);

console.log(result);