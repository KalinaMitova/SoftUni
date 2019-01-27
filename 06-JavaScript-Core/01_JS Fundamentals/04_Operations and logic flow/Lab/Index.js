//12. Prime Number Checker 
function primeNumberChecker(number) {
    if(number < 2){
        return false;
    }

    let sqrt = Math.floor(Math.sqrt(number));

    for (let index = 2; index <= sqrt; index++) {
        if(number % index == 0){
            return false;
        }
    }

    return true;
}

console.log(primeNumberChecker(47));

//11. Binary Logarithm 
function binaryLogarithm(array) {
    for (let number of array) {
        console.log(Math.log2(+number));
    }
}

//10. Chessboard
function chessboard(n) {
    let html = '<div class="chessboard">\n';

    for (let index = 0; index < n; index++) {
        html += '\t<div>\n';

        let color = index % 2 == 0 ? "black" : "white";
        for (let inner = 0; inner < n; inner++) {
            html += `\t\t<span class="${color}"></span>\n`;
            color = color == "black" ? "white" : "black";
        }

        html += '\t</div>\n';
    }

    html += '</div>\n';

    return html;
}

//9. Colorful Numbers 
function colorfulNumbers(n) {
    let html = "<ul>\n"

    for (let index = 1; index <= n; index++) {
        
        let color = index % 2 == 0 ? "blue" : "green";
        html += `<li><span style='color: ${color}'>${index}</span></li>\n`;
    }
    
    html += "</ul>";

    return html;
}

//8. Fruit or Vegetable 
function fruitOrVegetable(input) {
    switch(input){
        case "banana":
        case "apple":
        case "kiwi":
        case "cherry":
        case "lemon":
        case "grapes":
        case "peach":
            return "fruit";
        case "tomato":
        case "cucumber":
        case "pepper":
        case "onion":
        case "garlic":
        case "parsley":
            return "vegetable";
        default:
            return "unknown";
    }
}

//7. Odd / Even
function oddEven(number) {
    if(!Number.isInteger(number)){
        return "invalid";
    }

    return number % 2 == 0 ? "even" : "odd";
}

//6. Cone 
function cone(radius, height) {
    let v = (1/3) * (Math.PI * Math.pow(radius, 2) * height);
    let s = Math.sqrt(Math.pow(radius, 2) + Math.pow(height, 2));
    let l = Math.PI * radius * s;
    let b = Math.PI * Math.pow(radius, 2);
    let a = l + b;

    console.log(`volume = ${v}`);
    console.log(`area = ${a}`);
}

//5. Triangle Area
function triangleArea(a, b, c) {
    let p = (a + b + c) / 2;

    let s = Math.sqrt(p * (p - a) * (p - b) * (p - c));

    return s;
}

//4. Circle Area 
function circleArea(radius) {
    let area = Math.PI * Math.pow(radius, 2);

    console.log(area);
    console.log(area.toFixed(2));
}

//3. Leap Year 
function leapYear(year) {
    if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0){
        return "yes";
    }

    return "no";
}

//2. Boxes and Bottles 
function boxesAndBottels(bottles, boxCapacity) {
    return Math.ceil(bottles / boxCapacity);
}

//1. Multiply Numbers
function multiplyNumbers(a, b) {
    return a * b;
}