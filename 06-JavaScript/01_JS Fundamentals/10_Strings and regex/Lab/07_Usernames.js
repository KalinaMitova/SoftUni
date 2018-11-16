function solve(emails) {
    
    let usernames = [];

    emails.forEach(email => {
        let tokens = email.split("@");
        let username = `${tokens[0]}.${tokens[1].split('.').map(e => e[0]).join('')}`;
        usernames.push(username);
    });

    let output = usernames.join(", ");

    return output;
}

let result = solve(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);

console.log(result);