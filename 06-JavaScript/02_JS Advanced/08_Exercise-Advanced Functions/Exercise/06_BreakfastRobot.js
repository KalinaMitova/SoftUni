function solution() { 
    let recipts = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        coke: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        omelet: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        cheverme: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }; 

    let ingredientsStorage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    function manager(input) {
        let tokens = input.split(" ");
        let command = tokens[0];

        if(command === "restock") {
            let microelement = tokens[1];
            let quantity = +tokens[2];

            ingredientsStorage[microelement] += quantity;
            return `Success`;
        } else if (command === "prepare") {
            let recipe = tokens[1];            
            let quantity = +tokens[2];

            let neededIngredients = Object.keys(recipts[recipe]);

            for (const neededIngredient of neededIngredients) {
                if (recipts[recipe][neededIngredient] * quantity > ingredientsStorage[neededIngredient]) {                    
                    return `Error: not enough ${neededIngredient} in stock`;
                }
            }

            for (const neededIngredient of neededIngredients) {
                ingredientsStorage[neededIngredient] -= quantity * recipts[recipe][neededIngredient];
            }
            return `Success`;
        } else if (command === "report") {
            return `protein=${ingredientsStorage.protein} carbohydrate=${ingredientsStorage.carbohydrate} fat=${ingredientsStorage.fat} flavour=${ingredientsStorage.flavour}`;
        }
    };
    
    return manager;
}