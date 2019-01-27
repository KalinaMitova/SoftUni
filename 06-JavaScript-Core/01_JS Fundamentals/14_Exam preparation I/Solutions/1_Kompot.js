function solve(input) {
    
    let peachWeight = 140; // grams
    let plumWeight = 20; // grams
    let cherryWeight = 9; // grams

    let fruits = {
        forCompots: {
            peach: 0,
            cherry: 0,
            plum: 0,
        },
        forRakia: {

        },        
        compots: {
            peach: 0,
            cherry: 0,
            plum: 0,
        },
        rakia: 0
    };

    input.forEach((line) => {
        let tokens = line.split(" ").filter(e => e).map(e => e.trim());
        let fruit = tokens[0];
        let weight = +tokens[1];

        if (fruit === "peach" || fruit === "cherry" || fruit === "plum") {
            fruits.forCompots[fruit] += weight;
        } else {
            if(!fruits.forRakia.hasOwnProperty(fruit)) {
                fruits.forRakia[fruit] = 0;
            }

            fruits.forRakia[fruit] += weight;
        }
    });

    Object.keys(fruits.forCompots)
        .forEach((fruit) => {
            let weight = fruits.forCompots[fruit] * 1000;

            if(fruit === "peach") {
                fruits.compots[fruit] = Math.floor((weight / peachWeight) / 2.5);
            } else if (fruit === "cherry") {
                fruits.compots[fruit] = Math.floor((weight / cherryWeight) / 25);
            } else if (fruit === "plum") {
                fruits.compots[fruit] = Math.floor((weight / plumWeight) / 10);
            }
        })

    fruits.rakia = Object.keys(fruits.forRakia)
        .reduce((acc, fruit) => {
            let weight = fruits.forRakia[fruit];
            
            acc += weight * 0.2;

            return acc;
        }, 0);

    console.log(`Cherry kompots: ${fruits.compots.cherry}`);
    console.log(`Peach kompots: ${fruits.compots.peach}`);
    console.log(`Plum kompots: ${fruits.compots.plum}`);
    console.log(`Rakiya liters: ${fruits.rakia.toFixed(2)}`);
}

solve(['apple 6',
'peach 25.158',
'strawberry 0.200',
'peach 0.1',
'banana 1.55',
'cherry 20.5',
'banana 16.8',
'grapes 205.65'
,'watermelon 20.54']);