function solve(input) {
    let towns = [];
    let totalIncome = 0;

    input.forEach(element => {
        let [town, income] = element
            .split("|")
            .filter(e => e)
            .map(element => element.trim());
        towns.push(town);
        totalIncome += +income;
    });

    console.log(towns.join(", "));
    console.log(totalIncome);
}

solve(['| Sofia           | 300',
'| Veliko Tarnovo  | 500',
'| Yambol          | 275']
);