//07. Words Uppercase
function uppercase(sentance) {
    let regex = new RegExp(/\w+/g);
    let m;
    let words = [];

    do {
        m = regex.exec(sentance);
        if (m) {
            words.push(m[0].toLocaleUpperCase());
        }
    } while (m);

    let output = "";
    for (let i = 0; i < words.length; i++) {
        let element = words[i];
        
        output += element;
        if(words.length - 1 !== i) {
            output += ", ";
        }
    }

    return output;
}

console.log(uppercase('HI, HOW, ARE, YOU'));

//06. Aggregate Elements 
function aggregate(input) {
    let output = "";

    let firstLine = 0;
    let secondLine = 0;
    let thirdLine = "";

    for (let index = 0; index < input.length; index++) {
        let element = input[index];

        firstLine += +element;
        secondLine += 1 / +element;
        thirdLine += element.toString();
    }

    output += firstLine + "\n" + secondLine + "\n" + thirdLine;

    return output;
}

console.log(aggregate([1,2,3]))

//05. Functional Calculator 
function calculator(firstNumber, secondNumber, operator) {
    switch (operator) {
        case '+': return firstNumber + secondNumber;
        case '-': return firstNumber - secondNumber;
        case '*': return firstNumber * secondNumber;
        case '/': return firstNumber / secondNumber;
    }
}

//04. Day of Week 
function dayOfWeek(dayAsString) {
    switch (dayAsString.toLowerCase()) {
        case 'monday': return 1;
        case 'tuesday': return 2;
        case 'wednesday': return 3;
        case 'thursday': return 4;
        case 'friday': return 5;
        case 'saturday': return 6;    
        case 'sunday': return 7;    
        default: return "error";
    }
}

//03. Palindrome 
function polindrome(word) {

    let isPolindrome = true;

    for (let i = 0; i < word.length; i++) {        
        if (word[i] != word[word.length - i - 1]){
            isPolindrome = false;
            break;
        }
    }

    return isPolindrome;
}

//02. Square of Stars 
function squareOfStars(size) {
    if (size == null || size == undefined) {
        size = 5;
    }

    let output = "";

    for (let row = 1; row <= size; row++) {
        let line = "* ".repeat(size);

        output += line + "\n";
    }

    return output;
}

//01. Triangle of Stars 
function triangleOfStars(number) {
    let output = "";
    let length = number * 2 - 1;

    for (let i = 1; i <= length; i++) {
        let count = i;

        if(i > number) {
            count = number - (count - number);
        }

        let line = "*".repeat(count);
        output += line + "\n";
    }

    return output;
}
