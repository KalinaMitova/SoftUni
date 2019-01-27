function solve(commands) {
    let arr = [];
    let number = 1;

    commands.forEach((command) => {
        if(command.toLowerCase() === "add") {
            arr.push(number);
        } else if(command.toLowerCase() === "remove") {
            arr.pop();
        }

        number++;
    });

    if(arr.length === 0) {
        console.log("Empty");
    } else {
        arr.forEach((number) => {
            console.log(number);
        });
    }
}

solve(['remove', 
'remove', 
'remove']);