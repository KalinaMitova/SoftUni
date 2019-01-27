function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if(new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }

            this.weight = +weight;
            this.melonSort = melonSort;

            this._elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let output = `Element: ${this.element}\n`;
            output += `Sort: ${this.melonSort}\n`;
            output += `Element Index: ${this.elementIndex}`;

            return output;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {            
            super(weight, melonSort);

            this.element = "Water";
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {               
            super(weight, melonSort);

            this.element = "Fire";
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {             
            super(weight, melonSort);

            this.element = "Earth";
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {            
            super(weight, melonSort);

            this.element = "Air";
        }
    }

    class Melolemonmelon extends Airmelon {
        constructor(weight, melonSort) {           
            super(weight, melonSort);

            this.index = 1;
            this.element = "Water";
            this.elements = ["Water", "Fire", "Earth", "Air"];
        }

        morph() {
            this.element = this.elements[this.index];
            this.index++;
        }
    }

    return {Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon}
}

let result = solve();


let watermelon = new result.Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());

// Element: Water
// Sort: Kingsize
// Element Index: 100