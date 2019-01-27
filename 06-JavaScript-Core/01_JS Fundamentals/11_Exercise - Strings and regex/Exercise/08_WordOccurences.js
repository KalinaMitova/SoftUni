function solve(text, pattern) {
    let re = RegExp(`\\b${pattern}\\b`, "gi");
    let counter= 0;
    let m;

    do {
        m = re.exec(text);
        if(m) {
            counter++;
        }
    } while(m)

    return counter;
}

let result= solve('The waterfall was so high, that the child couldn’t see its peak.', 'the');
console.log(result);