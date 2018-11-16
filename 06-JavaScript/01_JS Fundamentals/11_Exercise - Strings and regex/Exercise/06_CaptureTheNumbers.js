function solve(input) {
    let pattern = /\d+/g;
    let re = RegExp(pattern);
    let numbers = [];
    let m;

    do {
        m = re.exec(input);
        if(m) {
            numbers.push(m[0]);
        }
    } while(m)

    return numbers.join(" ");
}

let result = solve(['The300', 
'What is that?', 
'I think it’s the 3rd movie.', 
'Lets watch it at 22:45']);

console.log(result);