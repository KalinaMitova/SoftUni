function solve(username, email, phoneNumber, textArr) {
    let usernamePattern = /<![A-Za-z]+!>/;
    let emailPattern = /<@[A-Za-z]+@>/;
    let phonePattern = /<\+[A-Za-z]+\+>/;

    textArr.forEach(element => {
        let result = element
            .replace(usernamePattern, username)
            .replace(emailPattern, email)
            .replace(phonePattern, phoneNumber);

        console.log(result);
    });
}

solve('Pesho',
'pesho@softuni.bg',
'90-60-90',
['Hello, <!username!>!',
 'Welcome to your Personal profile.',
 'Here you can modify your profile freely.',
 'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
 'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
 'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
);