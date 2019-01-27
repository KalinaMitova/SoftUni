function solve(text) {
    let re = RegExp(/\((.+?)\)/g);
    let matches = [];
    let match;

    do {
        match = re.exec(text);
        if (match) {
            matches.push(match[1]);
        }
    } while (match);

    return matches.join(", ");
}

let result = solve('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');