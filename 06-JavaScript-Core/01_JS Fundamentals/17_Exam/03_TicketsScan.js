function solve(text, command) {
    let namePattern = / [A-Z][A-Za-z]*\-[A-Z][A-Za-z]*(?:\.\-[A-Z][A-Za-z]*)? /g;
    let airportPattern = / [A-Z]{3}\/[A-Z]{3} /g;
    let flightNumberPattern = / [A-Z]{1,3}\d{1,5} /g;
    let companyPattern = /- ([A-Z][A-Za-z]*\*[A-Z][A-Za-z]*) /g;

    let name = namePattern.exec(text)[0].replace(/\-/g, " ").trim();
    let airport = airportPattern.exec(text)[0].trim().split("/");
    let flightNumber = flightNumberPattern.exec(text)[0].trim();
    let company = companyPattern.exec(text)[1].trim().replace("*", " ");

    if(command === "name") {
        console.log(`Mr/Ms, ${name}, have a nice flight!`);
    } else if (command === "flight") {
        console.log(`Your flight number ${flightNumber} is from ${airport[0]} to ${airport[1]}.`);        
    } else if (command === "company") {
        console.log(`Have a nice flight with ${company}.`);
    } else if (command === "all") {
        console.log(`Mr/Ms, ${name}, your flight number ${flightNumber} is from ${airport[0]} to ${airport[1]}. Have a nice flight with ${company}.`);
    }
}

solve(
    ' TEST-T.-TESTOV   SOF/VIE OS806 - Austrian*Airlines T24G55 STD11:15 STA11:50 ', 'flight');