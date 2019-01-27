function solve(matrixInput, forcesInput) {
    let matrix = matrixInput
        .map((element) => {
            return element.split(" ").map(e => +e);
        });

    let city = {
        map: matrix,
        breeze: function(row) {
            for (let column = 0; column < this.map[row].length; column++) {
                let newElement = this.map[row][column] - 15;
                if(newElement < 0) {
                    newElement = 0;
                }
                this.map[row][column] = newElement;
            }
        },
        gale: function(column) {
            for (let row = 0; row < this.map.length; row++) {
                let newElement = this.map[row][column] - 20;
                if(newElement < 0) {
                    newElement = 0;
                }
                this.map[row][column] = newElement;
            }
        },
        smog: function(value) {
            for (let row = 0; row < this.map.length; row++) {
                for (let col = 0; col < this.map[row].length; col++) {
                    this.map[row][col] += value;                    
                }
            }
        }
    }


    forcesInput.forEach((forceLine) => {
        let tokens = forceLine.split(" ").filter(e => e).map(e => e.trim());

        let force = tokens[0];
        let indexOrValue = +tokens[1];

        city[force](indexOrValue);
    })

    let output = [];

    city.map.forEach((row, rowIndex) => {
        row.forEach((element, colIndex) => {
            if (element >= 50) {
                output.push(`[${rowIndex}-${colIndex}]`);
            }
        });
    });

    if(output.length > 0) {
        console.log(`Polluted areas: ${output.join(", ")}`);
    } else {
        console.log("No polluted areas");
    }
}

solve([
    "5 7 72 14 4",
    "41 35 37 27 33",
    "23 16 27 42 12",
    "2 20 28 39 14",
    "16 34 31 10 24",
  ],
  ["breeze 1", "gale 2", "smog 25"]
  );