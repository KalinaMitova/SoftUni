function solve(input) {
    input
        .split("")
        .forEach((element, index) => console.log(`str[${index}] -> ${element}`));
}

solve('Hello, World!');