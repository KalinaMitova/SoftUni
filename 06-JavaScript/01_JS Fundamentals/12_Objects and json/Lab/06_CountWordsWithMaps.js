function solve(input) {
    let pattern = /\w+/g;
    let words = input[0].match(pattern)
    let map = new Map();
    
    words.forEach(word => {
        let lowerWord = word.toLowerCase();
        if(!map.has(lowerWord)) {
            map.set(lowerWord, 0);
        }
        map.set(lowerWord, map.get(lowerWord) + 1);
    });

    let sorted = new Map([...map.entries()].sort((a,b) => {
        return a[0].localeCompare(b[0]);
    }));

    sorted.forEach((value, key) => {
        console.log(`'${key}' -> ${value} times`);
    });
}

solve("Far too slow, you're far too slow.");