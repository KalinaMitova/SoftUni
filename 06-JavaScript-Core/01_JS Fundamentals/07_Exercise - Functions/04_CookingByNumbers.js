function solve(input) {

    let startPoint = +input[0];

    for (let i = 1; i < input.length; i++) {
        let operation = input[i].toLowerCase();
        
        let func = getFunction(operation);

        startPoint = func(startPoint);

        console.log(startPoint);
    }

    function getFunction(operation) {
        let chop = function(number) {
            return number / 2;
        }
    
        let dice = function(number) {
            return Math.sqrt(number);
        }
    
        let spice = function(number) {
            return number + 1;
        }
    
        let bake = function(number) {
            return number * 3;
        }
    
        let fillet = function(number) {
            return number - (number * 0.2);
        }
        
        switch (operation) {
            case "chop": return chop;
            case "dice": return dice;
            case "spice": return spice;
            case "bake": return bake;
            case "fillet": return fillet;
        }
    }    
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);