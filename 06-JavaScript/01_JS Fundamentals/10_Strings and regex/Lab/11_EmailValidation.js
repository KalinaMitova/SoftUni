function solve(input) {
    let re = RegExp(/^[A-Za-z0-9]+@[a-z]+.[a-z]+$/g);

    let match = re.exec(input);

    if(match) {
        console.log("Valid");
    } else {
        console.log("Invalid");
    }
}

solve('invalid@emai1.bg');