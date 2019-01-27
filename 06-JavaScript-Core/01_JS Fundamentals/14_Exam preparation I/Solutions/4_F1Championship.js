function solve(input) {
    let teams = {};

    input.forEach((line) => {
        let tokens = line.split(" -> ").filter(e => e).map(e => e.trim());

        let team = tokens[0];
        let pilot = tokens[1];
        let points = +tokens[2];

        if(!teams.hasOwnProperty(team)) {
            teams[team] = {
                pilots: {},
                teamPoints: 0
            };
        }

        if(Object.keys(teams[team].pilots).length <= 2) {
            if(!teams[team].pilots.hasOwnProperty(pilot)) {
                teams[team].pilots[pilot] = 0;
            }

            teams[team].pilots[pilot] += points;
            teams[team].teamPoints += points;
        }
    });

    Object.keys(teams)        
        .sort((a, b) => {
            return teams[b].teamPoints - teams[a].teamPoints;
        })
        .filter((v, i) => {
            return i < 3;
        })
        .forEach((team) => {
            console.log(`${team}: ${teams[team].teamPoints}`);

            Object.keys(teams[team].pilots)
                .sort((a, b) => {
                    return teams[team].pilots[b] - teams[team].pilots[a];
                })
                .forEach((pilot) => {
                    console.log(`-- ${pilot} -> ${teams[team].pilots[pilot]}`);
                });
        });;
}

solve(['Ferrari -> Kimi Raikonnen -> 25',
    'Ferrari -> Sebastian Vettel -> 18',
    'Mercedes -> Lewis Hamilton -> 10',
    'Mercedes -> Valteri Bottas -> 8',
    'Red Bull -> Max Verstapen -> 6',
    'Red Bull -> Daniel Ricciardo -> 4',
    'Mercedes -> Lewis Hamilton -> 25',
    'Mercedes -> Valteri Bottas -> 18',
    'Haas -> Romain Grosjean -> 25',
    'Haas -> Kevin Magnussen -> 25']);