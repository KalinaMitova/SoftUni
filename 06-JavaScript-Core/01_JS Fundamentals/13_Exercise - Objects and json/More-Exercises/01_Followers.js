function solve(input) {
    let users = {};

    input.forEach((inputLine) => {
        let tokens = inputLine
            .split(' ')
            .map(e => e.trim())
            .filter(e => e);

        if(tokens.length === 2) {
            let username = tokens[1];

            if(!users.hasOwnProperty(username)) {
                users[username] = {
                    username,
                    followers: new Set(),
                    followings: new Set()
                };
            }
        } else if (tokens.length === 3) {
            let follower = tokens[0];
            let followed = tokens[2];

            if(users.hasOwnProperty(follower) && 
                users.hasOwnProperty(followed) && follower !== followed) {
                    users[follower].followings.add(users[followed]);
                    users[followed].followers.add(users[follower]);
            }
        }
    });

    let usernames = Object.keys(users);

    console.log(`Total users registered: ${usernames.length}`);

    usernames
        .sort((a, b) => {
            return users[b].followers.size - users[a].followers.size ||
                b.localeCompare(a);
        })
        .forEach((user, index) => {
            console.log(`${index + 1}. ${user} : ${users[user].followings.size} following, ${users[user].followers.size} followers`);
            if(index === 0) {
                [...users[user].followers]
                    .sort((a, b) => {
                        return a.username.localeCompare(b.username)
                    })
                    .forEach((follower) => {
                        console.log(`*  ${follower.username}`);
                    });
            }
        });
}

solve(['Welcome, JennaMarbles',
'JennaMarbles followed Zoella',
'Welcome, AmazingPhil',
'JennaMarbles followed AmazingPhil',
'Welcome, Zoella',
'Welcome, JennaMarbles',
'Zoella followed AmazingPhil',
'Christy followed Zoella',
'Zoella followed Christy',
'Welcome, JacksGap',
'JacksGap followed JennaMarbles',
'Welcome, PewDiePie',
'Welcome, Zoella']);