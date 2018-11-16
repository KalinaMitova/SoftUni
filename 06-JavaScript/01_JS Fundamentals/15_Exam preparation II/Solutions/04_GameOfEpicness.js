function solve(kingdomsInput, fightsInput) {
    let kingdoms = {};

    kingdomsInput.forEach((kingdomInput) => {
        registerKingdom(kingdomInput);
    });

    fightsInput.forEach((fightInput) => {
        fight(fightInput);
    });
    
    let winner = getWinner();

    print(winner);

    function registerKingdom(kingdomInput) {
        if(!kingdoms[kingdomInput.kingdom]) {
            kingdoms[kingdomInput.kingdom] = {
                generals: {},
                totalWins: 0,
                totalLosses: 0
            };
        }

        if(!kingdoms[kingdomInput.kingdom]["generals"][kingdomInput.general]) {
            kingdoms[kingdomInput.kingdom]["generals"][kingdomInput.general] = {
                army: 0,
                wins: 0,
                losses: 0
            };
        }

        kingdoms[kingdomInput.kingdom]["generals"][kingdomInput.general].army += kingdomInput.army;
    }
    
    function fight(fightInput) {
        let attackingKingdom = fightInput[0];
        let attackingGeneral = fightInput[1];

        let defendingKingdom = fightInput[2];
        let defendingGeneral = fightInput[3];

        if(kingdoms[attackingKingdom] !== kingdoms[defendingKingdom]) {            
            if(kingdoms[attackingKingdom]["generals"][attackingGeneral].army > kingdoms[defendingKingdom]["generals"][defendingGeneral].army) {
                addArmy(attackingKingdom, attackingGeneral);
                removeArmy(defendingKingdom, defendingGeneral);
            } else if (kingdoms[attackingKingdom]["generals"][attackingGeneral].army < kingdoms[defendingKingdom]["generals"][defendingGeneral].army) {
                addArmy(defendingKingdom, defendingGeneral);
                removeArmy(attackingKingdom, attackingGeneral);
            }            
        }
    }

    function addArmy(kingdom, general) {
        let curArmy = kingdoms[kingdom]["generals"][general].army;
        let newArmy = Math.floor(curArmy + curArmy * 0.1);
        kingdoms[kingdom]["generals"][general].army = newArmy;
        kingdoms[kingdom]["generals"][general].wins++;
        kingdoms[kingdom].totalWins++;        
    }

    function removeArmy(kingdom, general) {
        let curArmy = kingdoms[kingdom]["generals"][general].army;
        let newArmy = Math.floor(curArmy - curArmy * 0.1);
        kingdoms[kingdom]["generals"][general].army = newArmy;
        kingdoms[kingdom]["generals"][general].losses++;
        kingdoms[kingdom].totalLosses++;
    }

    function getWinner() {
        let kingdomsKeys = Object.keys(kingdoms);

        kingdomsKeys.sort((a, b) => {
            return kingdoms[b].totalWins - kingdoms[a].totalWins || 
            kingdoms[a].totalLosses - kingdoms[b].totalLosses ||
            a.localeCompare(b);
        });

        return kingdomsKeys[0];
    }

    function print(winner) {
        console.log(`Winner: ${winner}`);
        Object.keys(kingdoms[winner]["generals"])
            .sort((a, b) => {
                return kingdoms[winner]["generals"][b].army - kingdoms[winner]["generals"][a].army;
            })
            .forEach((generalName) => {
                let general = kingdoms[winner]["generals"][generalName];
                console.log(`/\\general: ${generalName}`);
                console.log(`---army: ${general.army}`);
                console.log(`---wins: ${general.wins}`);
                console.log(`---losses: ${general.losses}`);
            });
    }
}

solve();