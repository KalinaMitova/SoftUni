class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = +budget;
        this.kids = {};
    }

    registerChild(name, grade, budget) {
        if(this.budget > budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        if(!this.kids[grade]) {
            this.kids[grade] = [];
        }

        let isExists = false;
        this.kids[grade].forEach((kid) => {
            if(kid.split('-')[0] === name) {
                isExists = true;
            }
        });

        if(isExists) {
            return `${name} is already in the list for this ${this.destination} vacation.`;
        } 

        this.kids[grade].push(`${name}-${budget}`);

        return this.kids[grade];
    }

    removeChild(name, grade) {
        if(this.kids[grade]) {
            let isExists = false;
            this.kids[grade].forEach((kid) => {
                if(kid.split('-')[0] === name) {
                    isExists = true;
                }
            });

            if(!isExists) {
                return `We couldn't find ${name} in ${grade} grade.`;
            }

            this.kids[grade] = this.kids[grade].filter((kid) => {
                return kid.split('-')[0] !== name;
            });

            return this.kids[grade];
        } else {
            return `We couldn't find ${name} in ${grade} grade.`;
        }
    }

    toString() {
        let kidsCount = this.numberOfChildren;

        if(kidsCount === 0) {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        } 
        
        let output = `${this.organizer} will take ${kidsCount} children on trip to ${this.destination}\n`;

        Object.keys(this.kids)
            .sort((a, b) => {
                return +a - +b;
            })
            .forEach((grade) => {
                if(this.kids[grade]) {
                    output += `Grade: ${grade}\n`;

                    this.kids[grade].forEach((kid, index) => {
                        output += `${index + 1}. ${kid}\n`;
                    });
                }
            });

        return output;        
    }

    get numberOfChildren() {
        return Object.keys(this.kids).reduce((acc, cur) => {            
            return acc += this.kids[cur].length;;
        }, 0);
    }
}

// Test 

// let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
// console.log(vacation.registerChild('Gosho', 5, 2000));
// console.log(vacation.registerChild('Lilly', 6, 2100));
// console.log(vacation.registerChild('Pesho', 6, 2400));
// console.log(vacation.registerChild('Gosho', 5, 2000));
// console.log(vacation.registerChild('Tanya', 5, 6000));
// console.log(vacation.registerChild('Mitko', 10, 1590));

// // Test 2
// let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
// vacation.registerChild('Gosho', 5, 2000);
// vacation.registerChild('Lilly', 6, 2100);

// console.log(vacation.removeChild('Gosho', 9));

// vacation.registerChild('Pesho', 6, 2400);
// vacation.registerChild('Gosho', 5, 2000);

// console.log(vacation.removeChild('Lilly', 6));
// console.log(vacation.registerChild('Tanya', 5, 6000))

// Test 3
let vacation = new Vacation('Miss Elizabeth', 'Dubai', 2000);

vacation.registerChild('Gosho', 5, 3000);
vacation.registerChild('Lilly', 6, 1500);
vacation.registerChild('Pesho', 7, 4000);
vacation.registerChild('Tanya', 5, 5000);
vacation.registerChild('Mitko', 10, 5500);

console.log(vacation.toString());
