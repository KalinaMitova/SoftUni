function solve(input) {

    for (let i = 0; i < input; i++) {
        let starts = "*".repeat(Math.abs(2 - (i % 4)));
        let lines = (i % 4) === 3 ? "-".repeat(2) : "-".repeat(((i % 4) * 2));
        
        let firstSymbol;
        let secondSybmol;

        ({ firstSymbol, secondSybmol } = GetSymbols(i, firstSymbol, secondSybmol));

        console.log(`${starts}${firstSymbol}${lines}${secondSybmol}${starts}`)
    }

    function GetSymbols(i, firstSymbol, secondSybmol) {

        let index = i % 5;
        switch (index) {
            case 0:
                firstSymbol = "A";
                secondSybmol = "T";
                break;
            case 1:
                firstSymbol = "C";
                secondSybmol = "G";
                break;
            case 2:
                firstSymbol = "T";
                secondSybmol = "T";
                break;
            case 3:
                firstSymbol = "A";
                secondSybmol = "G";
                break;
            case 4:
                firstSymbol = "G";
                secondSybmol = "G";
                break;
        }
        return { firstSymbol, secondSybmol };
    }
}

solve(10);