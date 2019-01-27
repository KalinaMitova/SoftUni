function solve(input) {
    let formulaOne = {
        race: [],
        join: function(racer) {
            this.race.push(racer);
        },
        crash: function(racer) {
            this.race = this.race.filter(r => r !== racer);
        },
        pit: function(racer) {
            let racerIndex = this.race.indexOf(racer);
            let newPositionIndex = racerIndex + 1;
            if(racerIndex > -1 && newPositionIndex < this.race.length) {
                this.race.splice(racerIndex, 0, this.race.splice(newPositionIndex, 1)[0]);
            }
        },
        overtake: function(racer) {
            let racerIndex = this.race.indexOf(racer);
            let newPositionIndex = racerIndex - 1;
            if(racerIndex > -1 && newPositionIndex > -1) {
                this.race.splice(racerIndex, 0, this.race.splice(newPositionIndex, 1)[0]);
            }
        },
        isInRace: function(racer) {
            return this.race.includes(racer);
        }
    };

    let raceInput = input.filter(e => e);
    formulaOne.race = raceInput.shift().split(" ").filter(e => e).map(e => e.trim());

    raceInput.forEach((inputLine) => {
        let tokens = inputLine.split(" ").filter(e => e).map(e => e.trim());

        let action = tokens[0].toLowerCase();
        let racer = tokens[1];

        let isInRace = formulaOne.isInRace(racer);

        if(action === "join" && !isInRace) {
            formulaOne.join(racer);
        } else if ((action === "crash" || action === "pit" || action === "overtake") && isInRace) {
            formulaOne[action](racer);
        }
    });

    console.log(formulaOne.race.join(" ~ "));
}

solve(["Vetel Hamilton Slavi",
"Pit Hamilton",
"Overtake Vetel",
"Crash Slavi"]);