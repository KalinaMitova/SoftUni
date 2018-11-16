function solve(input) {
    let splitPattern = /[\s\(\),.;]+/g;

    let split = input.split(splitPattern).filter(e => e);

    console.log(split.join("\n"));
}

solve('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');