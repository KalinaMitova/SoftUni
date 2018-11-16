//8. Distance between Points 
function distanceBetweenPoints(x1, y1, x2, y2){
    let pointA = {
        x: x1,
        y: y1
    };

    let pointB = {
        x: x2,
        y: y2
    };

    let x = Math.max(pointA.x, pointB.x) - Math.min(pointA.x, pointB.x);
    let y = Math.max(pointA.y, pointB.y) - Math.min(pointA.y, pointB.y);

    let result = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));

    console.log(result);
}

distanceBetweenPoints(2.34, 15.66, -13.55, -2.9985);

//7. Next Day 
function nextDay(year, month, day){
    let date = new Date(year, month - 1, day);
    
    let newdate = new Date(date);

    newdate.setDate(newdate.getDate() + 1);
    
    let dd = newdate.getDate();
    let mm = newdate.getMonth() + 1;
    let y = newdate.getFullYear();

    return `${y}-${mm}-${dd}`;
}

//6. Figure Area
function figureArea(w1, h1, w2, h2){
    let firstArea = w1 * h1;
    let secondArea = w2 * h2;

    let overlapArea = Math.min(w1, w2) * Math.min(h1, h2);

    let result = firstArea + secondArea - overlapArea;

    return result;
}

//5. String of Numbers 1..N 
function stringOfNumbers(number){
    let text = '';
    for (let index = 1; index <= +number; index++) {
        text += +index;        
    }

    return text;
}

//4. Filter By Age 
function filterByAge(filterAge, firstPersonName, firstPersonAge, secondPersonName, secondPersonAge){
    
    let firstPerson = {
            name: firstPersonName,
            age: firstPersonAge
        };

    if(firstPerson.age >= filterAge){
        console.log(firstPerson);
    }

    let secondPerson = {
            name: secondPersonName,
            age: secondPersonAge
        };
   
    if(secondPerson.age >= filterAge){
        console.log(secondPerson);
    }
}

//3. Letter Occurences In String 
function CountLetters(text, letter){
    let counter = 0;
    for(let character of text){
        if(character == letter){
            counter++;
        }
    }

    return counter;
}

//2. Calculate Sum and VAT 
function sumVat(input) {
    let sum = input.reduce((a,b)=>a+b);
    let vat =  sum * 0.2;
    let total = sum + vat;

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${vat}`);
    console.log(`total = ${total}`);
 }

//1. Sum 3 Numbers 
function sum(a, b, c){
    let sum = a + b + c;
    return sum;
}