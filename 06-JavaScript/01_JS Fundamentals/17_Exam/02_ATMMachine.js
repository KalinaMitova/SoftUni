function solve(input) {
    let atm = {
        banknotes: [],
        totalMoney: 0,
        insert: function(inputBanknotes) {
            let insertedCash = 0;
            inputBanknotes.forEach((banknote) => {
                this.banknotes.push(banknote);
                insertedCash += +banknote;
            });

            this.totalMoney += insertedCash;
            console.log(`Service Report: ${insertedCash}$ inserted. Current balance: ${this.totalMoney}$.`)
        },
        withdraw: function(accountBalance, amountToWithdraw) {
            if(accountBalance < amountToWithdraw) {
                console.log(`Not enough money in your account. Account balance: ${accountBalance}$.`);
            } else if (this.totalMoney < amountToWithdraw) {
                console.log(`ATM machine is out of order!`);
            } else {
                let sortedBanknotes = this.banknotes.sort((a, b) => {
                    return b - a;
                });

                let amount = amountToWithdraw;

                sortedBanknotes.forEach((banknote) => {
                    if(banknote <= amount) {                        
                        amount -= banknote;
                        this.totalMoney -= banknote;
                        this.banknotes.splice(this.banknotes.indexOf(banknote), 1);
                    }
                });

                console.log(`You get ${amountToWithdraw}$. Account balance: ${accountBalance - amountToWithdraw}$. Thank you!`);
            }
        },
        report: function(banknote) {
            let banknoteCount = this.banknotes.reduce((acc, cur) => {
                if(cur === banknote) {
                    acc++;
                }

                return acc;
            }, 0);

            console.log(`Service Report: Banknotes from ${banknote}$: ${banknoteCount}.`)
        }
    };

    input.forEach((line) => {
        if (line.length > 2) {
            atm.insert(line);
        } else if (line.length === 2) {
            let accountBalance = +line[0];
            let amountToWithdraw = +line[1];
            atm.withdraw(accountBalance, amountToWithdraw)
        } else {
            let banknote = line[0];
            atm.report(banknote);
        }
    });
}

solve([[20, 5, 100, 20, 1],
    [457, 25],
    [1],
    [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
    [20, 85],
    [5000, 4500],
   ]);