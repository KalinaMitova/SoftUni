function solve(input) {
    let areas = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    let driverSpeed = +input[0];
    let driverArea = input[1].toLowerCase();

    if(areas[driverArea] < driverSpeed) {
        let diff = driverSpeed - areas[driverArea];

        if (diff <= 20) {
            console.log("speeding");
        } else if (diff <= 40) {
            console.log("excessive speeding");
        } else {
            console.log("reckless driving");
        }
    }
}

solve([200, 'motorway']);