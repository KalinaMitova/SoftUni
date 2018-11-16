function solve(input) {
    let bitcoinPrice = 11949.16;
    let goldPrice = 67.51;
    let bitcoins = 0;
    let firstDay = 0;
    let money = 0;

    input.forEach((gold, index) => {
        let curGold;
        if((index + 1) % 3 === 0) {
            curGold = +gold - (+gold * 0.3);
        } else {
            curGold = +gold;
        }

        let price = curGold * goldPrice;
        money += price;

        if(money >= bitcoinPrice) {
            let bitcoinsCount = Math.floor(money / bitcoinPrice)
            bitcoins += bitcoinsCount;
            money -= bitcoinsCount * bitcoinPrice;
            if(!firstDay) {
                firstDay = index + 1;
            }
        }
    });

    console.log(`Bought bitcoins: ${bitcoins}`);
    if(firstDay) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`);
    }
    console.log(`Left money: ${money.toFixed(2)} lv.`);
}

solve([3124.15, 504.212, 2511.124])