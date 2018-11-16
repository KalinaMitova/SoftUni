function solve(input) {
    let pattern = /\b[\d]{1,2}-[A-Z]{1}[a-z]{2}-[\d]{4}\b/g;
    let re = RegExp(pattern);
    
    let dates = [];
    let m;

    input.forEach(element => {
        do {
            m = re.exec(element);
            if(m) {
                let date = m[0];
                let dateTokens = date.split("-");

                let dateString = `${date} (Day: ${dateTokens[0]}, Month: ${dateTokens[1]}, Year: ${dateTokens[2]})`;

                dates.push(dateString);
            }
        } while (m)
    });
    
    console.log(dates.join("\n"));
}

solve(['1-Jan-1999 is a valid date.',
'So is 01-July-2000.',
'I am an awful liar, by the way – Ivo, 28-Sep-2016.']);