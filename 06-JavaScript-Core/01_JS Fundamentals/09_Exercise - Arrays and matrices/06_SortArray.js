function solve(input) {
    input.sort((a, b) => {
        if(a.length === b.length) {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        } else {
            return a.length - b.length;
        }
    });

    input.forEach((element) => {
        console.log(element);
    });
}

solve(['test', 
'Deny', 
'omen', 
'Default']
);