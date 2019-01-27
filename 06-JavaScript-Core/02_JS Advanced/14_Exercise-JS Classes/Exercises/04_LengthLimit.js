class Stringer{
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
        
        Object.defineProperty(this, 'initialString', {
            value: innerString,
            writable: false
        });
        
        this.innerString = this.initialString.slice(0, this.innerLength);
        if(this.innerLength < this.initialString.length) {
            this.innerString += '...';
        }        
    }

    increase(val) {
        if(val < 0) {
            val = 0;
        }
       
        this.innerLength += val;

        this.innerString = this.initialString.slice(0, this.innerLength);
        if(this.innerLength < this.initialString.length) {
            this.innerString += '...';
        }        
    }

    decrease(val) {
        if(val < 0) {
            val = 0;
        }

        if(val > this.innerLength) {
            val = this.innerLength;
        }

        this.innerLength -= val;

        this.innerString = this.initialString.slice(0, this.innerLength);
        if(this.innerLength < this.initialString.length) {
            this.innerString += '...';
        }
    }

    toString() {
        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
