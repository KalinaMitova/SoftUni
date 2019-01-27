solve([6, 4]);

function solve(input) {
    
    for (let i = 0; i < input.length; i += 2) {
        let x = +input[i];
        let y = +input[i + 1];
        
        console.log(checkIsInIsland(x, y));
    }

    function checkIsInIsland(x, y) {
        let islands = [{
            name: "Tuvalu",
            position: {
                x: 1,
                y: 1
            },
            size: {
                x: 2,
                y: 2
            }
        }, {
            name: "Tokelau",
            position: {
                x: 8,
                y: 0
            },
            size: {
                x: 1,
                y: 1
            }
        }, {
            name: "Samoa",
            position: {
                x: 5,
                y: 3
            },
            size: {
                x: 2,
                y: 3
            }
        }, {
            name: "Tonga",
            position: {
                x: 0,
                y: 6
            },
            size: {
                x: 2,
                y: 2
            }
        }, {
            name: "Cook",
            position: {
                x: 4,
                y: 7
            },
            size: {
                x: 5,
                y: 1
            }
        }];
        
        for (let island of islands) {
            if((island.position.x <= x && island.position.x + island.size.x >= x) &&
                (island.position.y <= y && island.position.y + island.size.y >= y)) {
                    return island.name;
            }
        }

        return "On the bottom of the ocean";
    }
}

