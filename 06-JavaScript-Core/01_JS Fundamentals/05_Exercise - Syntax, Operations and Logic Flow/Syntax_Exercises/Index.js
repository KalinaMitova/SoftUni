//13. Last Month 
function lastMonth(input) {
    // let day = +input[0];
    let month = +input[1];
    let year = +input[2];

    const date = new Date(year, month - 1, 0);

    return date.getDate();
}

//12. Assign Properties 
function assignProperties(input) {
   let object = {};

   for (let index = 0; index < input.length; index += 2) {
       const key = input[index];
       const value = input[index + 1];

       object[key] = value;
   }

    return object;
}

assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']);

//11. Binary to Decimal
function binaryToDecimal(input) {
    return parseInt(input, 2);
}

//10. Compose Tag 
function composeTag(input) {
    let fileLocation = input[0];
    let alternateText = input[1];

    return `<img src="${fileLocation}" alt="${alternateText}">`
}

//09. Now Playing 
function nowPlaying(input) {
    //Now Playing: {artist name} - {track name} [{duration}]
    let trackName = input[0];
    let trackArtist = input[1];
    let trackDuration = input[2];

    return `Now Playing: ${trackArtist} - ${trackName} [${trackDuration}]`
}

//08. Imperial Units 
function imperalUnits(totalInches) {
    let feets = totalInches / 12 >> 0;
    let inches = totalInches % 12;

    return `${feets}'-${inches}"`;
}

//07. Rounding 
function rounding(input) {
    let number = +input[0];
    let precision = +input[1];

    if(precision > 15){
        precision = 15;
    }

    return +(Math.round(number + `e+${precision}`)  + `e-${precision}`);
}

//06. Compound Interest 
function compoundInteres(input) {
    let principalSum = +input[0];
    let interestRate = +input[1]; // in percent
    let compoundingPeriod = +input[2]; // in months 
    let totalTimespan = +input[3]; // in years

    let n = 12 / compoundingPeriod;

    let compoundInterest = principalSum * Math.pow(1 + interestRate / 100 / n, n * totalTimespan);

    return compoundInterest;
}

//05. Grads to Radians 
function gradsToRadians(grads) {
    let degrees = grads * 0.9;

    let remainder = degrees % 360;

    if(remainder < 0){
        remainder += 360;
    }

    return remainder;
}

//04. Distance in 3D 
function distanceIn3D(input) {
    let pointA = {
        x: +input[0],
        y: +input[1],
        z: +input[2]
    };

    let pointB = {
        x: +input[3],
        y: +input[4],
        z: +input[5]
    };

    let distance = Math.sqrt(
        Math.pow(pointA.x - pointB.x, 2) +
        Math.pow(pointA.y - pointB.y, 2) +
        Math.pow(pointA.z - pointB.z, 2));

    return distance;
}

//03. Distance over Time 
function distanceOverTime(input) {
    let v1 = (+input[0] / 60) / 60;
    let v2 = (+input[1] / 60) / 60 ;
    let t = +input[2];

    let s1 = v1 * t;
    let s2 = v2 * t;

    let distanceBetweenObjects = (Math.max(s1, s2) - Math.min(s1, s2)) * 1000;

    return distanceBetweenObjects;
}

//02. Area and Perimeter 
function areaPerimeter(sideA, sideB) {
    let area = sideA * sideB;
    let perimeter = (sideA + sideB) * 2;

    console.log(area);
    console.log(perimeter);
}

// 01. Hello JavaScript!
function greeting(name) {
    return `Hello, ${name}, I am JavaScript!`;
}