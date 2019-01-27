solve([1000, 4022, 8155]);

function solve(input) {

    let target = +input[0];
    
    for (let i = 1; i < input.length; i++) {
        let crystal = +input[i];
        
        console.log(`Processing chunk ${crystal} microns`);

        crystal = action(crystal, cut, "Cut");
        if(crystal === target) {
            console.log(`Finished crystal ${crystal} microns`);
            continue;
        }

        crystal = action(crystal, lap, "Lap");
        if(crystal === target) {
            console.log(`Finished crystal ${crystal} microns`);
            continue;
        }
        
        crystal = action(crystal, grind, "Grind");
        if(crystal === target) {
            console.log(`Finished crystal ${crystal} microns`);
            continue;
        }
        
        crystal = action(crystal, etch, "Etch");
        if(crystal === target) {
            console.log(`Finished crystal ${crystal} microns`);
            continue;
        }

        crystal = xRay(crystal);
        console.log(`X-ray x1`);

        console.log(`Finished crystal ${crystal} microns`);
    }

    function action(crystal, func, name) {
        let counter = 0;
        
        while (target - 1 <= func(crystal)) {
            crystal = func(crystal);
            counter++;
        }

        if(counter !== 0) {
            console.log(`${name} x${counter}`);
            crystal = transportingAndWashing(crystal);
        }
        
        return crystal;
    }

    function cut(number) {
        return number / 4;
    }

    function lap(number) {
        return number - (number * 0.2);
    }

    function grind(number) {
        return number - 20;
    }

    function etch(number) {
        return number - 2;
    }

    function xRay(number) {
        return number + 1;
    }

    function transportingAndWashing(number) {
        console.log("Transporting and washing");
        return Math.floor(number);
    }
}