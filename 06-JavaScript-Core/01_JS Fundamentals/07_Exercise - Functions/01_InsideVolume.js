function solve(numbers) {
    for (let i = 0; i < numbers.length; i += 3) {
        let x = numbers[i],
            y = numbers[i + 1],
            z = numbers[i + 2];

        if(isInsideVolume(x, y, z)) {
            console.log("inside");
        } else {
            console.log("outside");
        }
    }

    function isInsideVolume(x, y, z) {
        let x1 = 10, x2 = 50,
            y1 = 20, y2 = 80,
            z1 = 15, z2 = 50;
    
        if((x >= x1 && x <= x2) && (y >= y1 && y <= y2) && (z >= z1 && z <= z2)) {
            return true;
        }
        
        return false;
    }
}

solve([13.1, 50, 31.5, 50, 80, 50, -5, 18, 43]);