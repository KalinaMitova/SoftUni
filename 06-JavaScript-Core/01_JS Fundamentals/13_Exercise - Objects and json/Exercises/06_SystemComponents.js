function solve(input) {
    let systems = {};

    input.forEach((systemInput) => {
        let tokens = systemInput.split(" | ");
        let system = tokens[0];
        let component = tokens[1];
        let subcomponent = tokens[2];

        if(systems[system] === undefined) {
            systems[system] = {};
        }

        if(systems[system][component] === undefined) {
            systems[system][component] = [];
        }

        systems[system][component].push(subcomponent);
    });


    let systemKeys = Object.keys(systems);
    systemKeys.sort((a, b) => {
        let aKeys = Object.keys(systems[a]).length;
        let bKeys = Object.keys(systems[b]).length;

        if(aKeys === bKeys) {
            return a.toLocaleLowerCase().localeCompare(b.toLocaleLowerCase());
        }

        return bKeys - aKeys;
    });

    systemKeys.forEach((systemKey) => {
        let componentKeys = Object.keys(systems[systemKey]);

        componentKeys.sort((a, b) => {
            return systems[systemKey][b].length - systems[systemKey][a].length;
        });

        console.log(systemKey);
        componentKeys.forEach((componentKey) => {
            console.log(`|||${componentKey}`);

            let subcomponents = systems[systemKey][componentKey];
            subcomponents.forEach((subcomponent) => {
                console.log(`||||||${subcomponent}`);
            });
        });
    });
}

solve(['SULS | Main Site | Home Page',
        'SULS | Main Site | Login Page',
        'SULS | Main Site | Register Page',
        'SULS | Judge Site | Login Page',
        'SULS | Judge Site | Submittion Page',
        'Lambda | CoreA | A23',
        'SULS | Digital Site | Login Page',
        'Lambda | CoreB | B24',
        'Lambda | CoreA | A24',
        'Lambda | CoreA | A25',
        'Lambda | CoreC | C4',
        'Indice | Session | Default Storage',
        'Indice | Session | Default Security']);