function solve(input) {   
    function getEngine(power) {
        let engines = {
            smallEngine: { power: 90, volume: 1800 },
            normalEngine: { power: 120, volume: 2400 },
            monsterEngine: { power: 200, volume: 3500 }
        };

        let engine = Object.keys(engines)
            .reduce((acc, cur) => {
                
                let curEngine = engines[cur];
                
                let diff = Math.abs(curEngine.power - input.power);
                
                if(diff < acc.diff) {
                    acc.best = cur;
                    acc.diff = diff;
                }

                return acc;
            }, { best: "", diff: Number.MAX_VALUE });

        return engines[engine.best];
    }

    function getCarriage(carriageName, color) {
        let carriages = {
            hatchback: { type: 'hatchback', color },
            coupe: { type: 'coupe', color },        
        };

        return carriages[carriageName];
    }

    function getWheels(size) {
        let wheelSize = size;

        if(wheelSize % 2 === 0) {
            wheelSize -= 1;
        }

        return [wheelSize, wheelSize, wheelSize, wheelSize];
    }

    let car = { 
        model: input.model,
        engine: getEngine(input.power),
        carriage: getCarriage(input.carriage, input.color),
        wheels: getWheels(input.wheelsize)
    };

    return car;  
}

solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);