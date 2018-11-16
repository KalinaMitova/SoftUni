function solve(input) {
    let step = +input.pop();

    for (let i = 0; i < input.length; i+=step) {
        let element = input[i];
        console.log(element);
    }
}

solve(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
)