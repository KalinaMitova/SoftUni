function solve(input) {
    let getsPattern = /(.+) gets (.+)/;
    let fullPattern = /(.+) visited the (.+) in (.+) - (.+)/;

    let log = {
        travellers: {}
    };

    input.forEach((inputLine) => {
        let match = getsPattern.exec(inputLine);

        if(match) {
            let traveller = match[1];
            let money = +match[2];

            if(!log.travellers.hasOwnProperty(traveller)) {
                log.travellers[traveller] = {
                    countries: {},
                    countriesCount: 0,
                    money: 0
                }
            }

            log.travellers[traveller].money += money;            
        } else {
            match = fullPattern.exec(inputLine);

            if(match) {
                let traveller = match[1];
                let country = match[3];
                let landmark = match[2];
                let cost = +match[4];
                
                if(!log.travellers.hasOwnProperty(traveller)) {
                    log.travellers[traveller] = {
                        countries: {},
                        countriesCount: 0,
                        money: 0
                    }
                }

                if(log.travellers[traveller].money >= cost) {
                    if(!log.travellers[traveller].countries.hasOwnProperty(country)) {
                        log.travellers[traveller].countries[country] = {
                            landmarks: {},
                            landmarksCount: 0
                        };
                        log.travellers[traveller].countriesCount++;
                    }
    
                    if(!log.travellers[traveller].countries[country].landmarks.hasOwnProperty(landmark)) {
                        log.travellers[traveller].countries[country].landmarks[landmark] = cost;
                        log.travellers[traveller].countries[country].landmarksCount++;
                        log.travellers[traveller].money -= cost;
                    }
                } else if(!log.travellers[traveller].countries.hasOwnProperty(country) ||
                    !log.travellers[traveller].countries[country].landmarks.hasOwnProperty(landmark)) {
                    console.log(`Not enough money to visit ${landmark}`);
                }
            }
        }
    });

    let travellers = Object.keys(log.travellers);

    travellers
        .sort((a, b) => {
            return log.travellers[b].countriesCount - log.travellers[a].countriesCount;
        })
        .forEach((traveller) => {
            let countriesCount = log.travellers[traveller].countriesCount;
            let money = log.travellers[traveller].money;

            console.log(`${traveller} visited ${countriesCount} countries and has ${money} money left`);

            Object.keys(log.travellers[traveller].countries)
                .sort((a, b) => {
                    return log.travellers[traveller].countries[b].landmarksCount - log.travellers[traveller].countries[a].landmarksCount;
                })
                .forEach((country) => {            
                    let lаndmarksCount = log.travellers[traveller].countries[country].landmarksCount;
                    console.log(`- ${country} -> ${lаndmarksCount} landmarks`);

                    Object.keys(log.travellers[traveller].countries[country].landmarks)
                        .sort((a, b) => {
                            return a.localeCompare(b);
                        })
                        .forEach((lendmark) => {
                            console.log(`-- ${lendmark}`);
                        })
                })
        });
}