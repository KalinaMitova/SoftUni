// function solve(input) {
//     let main = 0;
//     let secondary = 0;

//     for (let i = 0; i < input.length; i++) {
//         main += +input[i][i];
//         secondary += +input[i][input.length - 1 - i];
//     }

//     console.log(`${main} ${secondary}`);
// }

function solve(input) {
    let [main, secondary] = input
        .map((item, index) => {

            let items = item
                .filter((innerItem, innerIndex) => {                    
                    return (innerIndex === index || innerIndex === item.length - 1 - index);
                });

            if(index > input.length - 1 / 2) {
                return items.reverse();
            }

            if(items.length === 1) {
                return items.concat(items);
            }

            return items;
        })
        .reduce((acc, cur) => {
            return [acc[0] + cur[0], acc[1] + cur[1]];
        });

    console.log(`${main} ${secondary}`);
}

let result = solve([[20, 11, 40, 12, 13],
    [10, 12, 6, 0, 15],
    [5, 18, 23, 87, 34],
    [10, 12, 60, 25, 4],
    [5, 18, 23, 1, 2]]);

console.log(result);
