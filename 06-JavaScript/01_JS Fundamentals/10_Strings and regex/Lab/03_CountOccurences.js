function solve(target, element) {
    let counter = 0;
    let start = 0;
    let index;

    do {
        index = element.indexOf(target, start);
        if(index > 0) {
            counter++;
            start = index + 1;
        }
    }
    while(index > 0)

    return counter;
}

solve('the', 'The quick brown fox jumps over the lay dog.');