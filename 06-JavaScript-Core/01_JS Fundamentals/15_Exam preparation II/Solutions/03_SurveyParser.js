function solve(input) {
    let surveyDataPattern = /<svg>(.+?)<\/svg>/g;
    let catPattern = /\s*<cat><text>.*\[(.+)\].*<\/text><\/cat>\s*<cat>(.*(?:<g><val>(?:10|[1-9])<\/val>\d+<\/g>)+.*)<\/cat>\s*/g;
    let valPattern = /<g><val>(10|[1-9])<\/val>(\d+)<\/g>/g;

    let totalRating = 0;
    let votes = 0;

    let surveyDataMatch = surveyDataPattern.exec(input);
    if(surveyDataMatch) {
        let catMatch = catPattern.exec(surveyDataMatch[1]);

        if(catMatch) {
            let label = catMatch[1].trim();

            let valMatch;
            do {
                valMatch = valPattern.exec(catMatch[2]);
                if(valMatch) {
                    let value = +valMatch[1];
                    let voteCount = +valMatch[2];

                    totalRating += value * voteCount;
                    votes += voteCount;
                }
            } while(valMatch)

            console.log(`${label}: ${parseFloat((totalRating / votes).toFixed(2))}`);
        } else {
            console.log("Invalid format");
        }
    } else {
        console.log("No survey found");
    }
}

solve(`<svg><cat><text>How do you rate the special menu? [Food - Special]</text></cat> <cat><g><val>1</val>5</g><g><val>5</val>13</g><g><val>10</val>22</g></cat></svg>`);