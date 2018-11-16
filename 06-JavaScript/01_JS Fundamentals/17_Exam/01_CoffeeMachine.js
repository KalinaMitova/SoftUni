function solve(input) {
    let prices = {
        "caffeine": 0.8,
        "decaf": 0.9,
        "tea": 0.8
    }

    let totalMoney = 0;
    
    input.forEach((element) => {
        let tokens = element.split(", ").filter(e => e).map(e => e.trim());

        let coins = +tokens[0];
        let drinkType = tokens[1];
        let haveMilk = tokens.includes("milk");
        let sugarQuantity = +tokens[tokens.length - 1];
        let coffieType;
        
        let productPrice;
        if(drinkType === "coffee") {
            coffieType = tokens[2];
            productPrice = prices[coffieType];         
        } else if (drinkType === "tea") {
            productPrice = prices["tea"];
        }

        if(haveMilk) {
            productPrice += +(productPrice * 0.1).toFixed(1);
        }   

        if(sugarQuantity > 0 && sugarQuantity <= 5) {
            productPrice += 0.1;
        }

        if(coins >= productPrice) {
            let change = Math.abs(coins - productPrice).toFixed(2);
            totalMoney += productPrice;
            console.log(`You ordered ${drinkType}. Price: ${productPrice.toFixed(2)}$ Change: ${change}$`);
        } else {
            let moneyNeeded = Math.abs(productPrice - coins).toFixed(2);
            console.log(`Not enough money for ${drinkType}. Need ${moneyNeeded}$ more.`);
        }
    });

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`)
}

solve(['1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0',]);