function solve(input) {
    let re = RegExp(/\w+/, "g");
    let words = [];

    let m;
    do {
        m = re.exec(input);
        if(m) {
            words.push(m[0]);
        }
    } while(m)

    console.log(words.join("|"));
}

solve('_(Underscores) are also word characters');