function solve(words) {
    return words
        .split(" ")
        .map(element => {
            let word = element.split("");

            return word.shift().toUpperCase() + word.join("").toLowerCase();
        })
        .join(" ");    
}

let result = solve('Was that Easy? tRY thIs onE for SiZe!');
console.log(result);