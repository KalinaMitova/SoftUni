//22. Monthly Calendar
function monthlyCalendar(input) {
    let day = +input[0];
    let month = +input[1] - 1;
    let year = +input[2];

    let date = new Date(year, month, 1);
    
    let dayOfWeek = date.getDay();    
    date.setDate(date.getDate() - dayOfWeek);

    let calendar = 
        "<table>\n\t<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n";
    
    do {
        let line = '\t<tr>';

        for (let col = 0; col < 7; col++) {
            let currentDate = date.getDate();
            let currentMonth = date.getMonth();

            if (currentDate === day && currentMonth === month) {
                line += `<td class="today">${currentDate}</td>`;
            } else if ((currentMonth > month && !(month === 0 && currentMonth === 11)) || (currentMonth === 0 && month === 11)) {
                line += `<td class="next-month">${currentDate}</td>`;
            } else if(currentMonth < month || (month === 0 && currentMonth === 11)) {
                line += `<td class="prev-month">${currentDate}</td>`;
            } else {
                line += `<td>${currentDate}</td>`;
            }

            date.setDate(currentDate + 1);
        }

        line += '</tr>';

        calendar += line + "\n";
    } while(date.getMonth() === month)
            
    calendar += "</table>";

    return calendar;
}

//21. Figure of 4 Squares
function figureOfFourSquares(n) {
    let html = "";

    let lineLength = n % 2 === 0 ? n - 1 : n;
    let middleLength = (2 * n) - 3;

    let baseChar;
    let midChar;

    for (let row = 0; row < lineLength; row++) {
        baseChar = row === (lineLength / 2) >> 0 || row === 0 || row === lineLength - 1 ? "+" : "|";
        midChar = row === (lineLength / 2) >> 0 || row === 0 || row === lineLength - 1 ? "-" : " ";

        let line = baseChar;

        for (let col = 0; col < middleLength; col++) {

            if(col == (middleLength / 2) >> 0) {
                line += baseChar;
            }
            else {
                line += midChar;
            }
        }

        line += baseChar;

        html += line + "\n";
    }

    return html;
}

//20. Multiplication Table 
function multiplicationTable(n) {
    let html = '<table border="1">\n';

    // firs row
    html += `\t<tr><th>x</th>`;
    for (let i = 1; i <= +n; i++) {
        html += `<th>${i}</th>`;
    }
    html += "</tr>\n";

    for (let i = 1; i <= +n; i++) {
        html += `\t<tr><th>${i}</th>`
        for (let j = 1; j <= +n; j++) {
            html += `<td>${i * j}</td>`;
        }  
        html += "</tr>\n";
    }

    html += "</table>";

    return html;
}

//19. Quadratic Equation 
function quadraticEquation(a, b, c) {
    let discriminant = Math.pow(b, 2) - 4 * a * c;

    if(discriminant > 0) {
        let x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
        let x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
        
        console.log(Math.min(x1, x2));
        console.log(Math.max(x1, x2));
    }
    else if (discriminant === 0) {
        let x = (-b + Math.sqrt(discriminant)) / (2 * a);

        console.log(x);
    }
    else {
        console.log("No");
    }
}

//18. Movie Prices 
function moviePrices(input) {
    let movies = {
        "the godfather": {
            pricesByWeeks: {
                "monday": 12,
                "tuesday": 10,
                "wednesday": 15,
                "thursday": 12.50,
                "friday": 15,
                "saturday": 25,
                "sunday": 30,
            }
        },
        "schindler's list": {
            pricesByWeeks: {
                "monday": 8.50,
                "tuesday": 8.50,
                "wednesday": 8.50,
                "thursday": 8.50,
                "friday": 8.50,
                "saturday": 15,
                "sunday": 15,
            }
        },"casablanca": {
            pricesByWeeks: {
                "monday": 8,
                "tuesday": 8,
                "wednesday": 8,
                "thursday": 8,
                "friday": 8,
                "saturday": 10,
                "sunday": 10,
            }
        },"the wizard of oz": {
            pricesByWeeks: {
                "monday": 10,
                "tuesday": 10,
                "wednesday": 10,
                "thursday": 10,
                "friday": 10,
                "saturday": 15,
                "sunday": 15,
            }
        }
    }

    let movieInput = input[0].toLowerCase();
    let dayOfWeekInput = input[1].toLowerCase();

    let movie = movies[movieInput];

    if(movie == undefined){
        return "error";
    }

    let result = movie.pricesByWeeks[dayOfWeekInput];

    if(result == undefined){
        return "error";
    }

    return result;
}

//17. Triangle of Dollars 
function triangleOfDollars(n) {
    let triangle = "";

    for (let index = 1; index <= +n; index++) {
        let line = "";
        for (let inner = 1; inner <= index; inner++) {
            line += "$";            
        }

        triangle += line + "\n";        
    }

    return triangle;
}

//16. Odd Numbers 1 to N 
function oddNumbers(n) {
    for (let index = 1; index <= +n; index += 2) {
        console.log(index);
    }
}

//15. Point in Rectangle 
function pointInRectangle(input) {
    let x = +input[0];
    let y = +input[1];
    let xMin = +input[2];
    let xMax = +input[3];
    let yMin = +input[4];
    let yMax = +input[5];

    let isInX = x >= xMin && x <= xMax;
    let isInY = y >= yMin && y <= yMax;

    return isInX && isInY ? "inside" : "outside";
}

//14. Biggest of 3 Numbers 
function biggestNumber(input) {
    let biggest = +input[0];

    for (const number of input) {
        if(biggest < +number) {
            biggest = +number;
        }
    }

    return biggest;
}