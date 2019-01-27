function solve(input) {
    let usernames = {};

    input.forEach((username) => {
        if(usernames[username] === undefined) {
            usernames[username] = 0;
        }
    });

    let keys = Object.keys(usernames);
    keys.sort((a, b) => {
        let aLength = a.length;
        let bLength = b.length;

        if(aLength === bLength) {
            return a.localeCompare(b);
        }

        return aLength - bLength;
    });

    return keys.join("\n");
}

solve(['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston']);