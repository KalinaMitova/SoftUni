function solve(input) {
    let gladiators = {};

    input.forEach((inputLine) => {
        let tokens = inputLine.split(/ -> | vs /g);

        if(tokens.length === 3) {
            let name = tokens[0];
            let technique = tokens[1];
            let skill = +tokens[2];

            registerGladiator(name, technique, skill);
        } else if (tokens.length === 2) {            
            let firstGladiator = tokens[0];
            let secondGladiator = tokens[1];

            fight(firstGladiator, secondGladiator);
        } else if (tokens[0] === "Ave Cesar") {
            printResult();
            return;
        }
    });

    function registerGladiator(name, technique, skill) {
        if (!gladiators[name]) {
            gladiators[name] = {
                "techniques": {},
                "totalSkills": 0
            };
        }
        if (!gladiators[name]["techniques"][technique] || gladiators[name]["techniques"][technique] < skill) {
            let prevSkill = gladiators[name]["techniques"][technique];
            if (prevSkill === undefined) {
                prevSkill = 0;
            }
            gladiators[name]["techniques"][technique] = skill;
            gladiators[name]["totalSkills"] += skill - prevSkill;
        }
    }

    function fight(firstGladiator, secondGladiator) {
            if(gladiators[firstGladiator] && gladiators[secondGladiator]) {
                let firstGladiatorTechniques = Object.keys(gladiators[firstGladiator]["techniques"]);
                let secondGladiatorTechniques = Object.keys(gladiators[secondGladiator]["techniques"]);

                let isIncludes = false;
                for (let i = 0; i < firstGladiatorTechniques.length; i++) {
                    const technique = firstGladiatorTechniques[i];
                    
                    if (secondGladiatorTechniques.includes(technique)) {
                        isIncludes = true;
                        break;
                    }
                }

                if(isIncludes) {
                    if(gladiators[firstGladiator].totalSkills > gladiators[secondGladiator].totalSkills) {
                        gladiatorToRemove = secondGladiator;
                        removeGladiator(secondGladiator);
                    }
                    else if (gladiators[firstGladiator].totalSkills < gladiators[secondGladiator].totalSkills) {
                        removeGladiator(firstGladiator);
                    }
                }
            }
    }

    function printResult() {
        let gladiatorKeys = Object.keys(gladiators);

        gladiatorKeys
            .sort((a, b) => {
                return gladiators[b].totalSkills - gladiators[a].totalSkills || a.localeCompare(b);
            })
            .forEach((gladiator) => {
                console.log(`${gladiator}: ${gladiators[gladiator].totalSkills} skill`);

                let techniques = Object.keys(gladiators[gladiator]["techniques"]);

                techniques
                    .sort((a, b) => {
                        let aSkill = gladiators[gladiator]["techniques"][a];
                        let bSkill = gladiators[gladiator]["techniques"][b];

                        return bSkill - aSkill || a.localeCompare(b);
                    })
                    .forEach((techniqueKey) => {
                        let skill = gladiators[gladiator]["techniques"][techniqueKey];
                        console.log(`- ${techniqueKey} <!> ${skill}`);
                    });
            });
    }

    function removeGladiator(gladiatorName) {
        let gladiatorNames = Object.keys(gladiators);

        gladiators = gladiatorNames.reduce((acc, cur) => {
            if(gladiatorName !== cur) {
                acc[cur] = gladiators[cur];
            }
            return acc;
        }, {});
    }
}

solve(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar'
    ]);