class Vacationer {
    constructor(fullName, creditCard) {

        this.fullName = fullName;

        this.generateIDNumber();
        
        if(creditCard) {
            this.creditCard = creditCard;
        } else {
            this.creditCard = [1111, "", 111];
        }

        this.wishList = [];
    }

    get creditCard() {
        return this._creditCard;
    }

    set creditCard(val) {
        if(val.length != 3) {
            throw new Error("Missing credit card information");
        }

        if(typeof val[0] !== 'number' || typeof val[2] !== 'number') {
            throw new Error("Invalid credit card details");
        }

        let card = {
            cardNumber: val[0],
            expirationDate: val[1],
            securityNumber: val[2],
        }

        this._creditCard = card;
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(val) {
        if(val.length !== 3) {
            throw new Error("Name must include first name, middle name and last name");
        }

        val.forEach((name) => {
            if(!(name.match(/^[A-Z][a-z]*$/))) {
                throw new Error("Invalid full name");
            }
        });

        this._fullName = {
            firstName: val[0],
            middleName: val[1],
            lastName: val[2],
        };
    }

    generateIDNumber() {
        let idNumber = 231 * this.fullName.firstName.charCodeAt(0) + 
            139 * this.fullName.middleName.length;

        let lastName = this.fullName.lastName;
        let lastChar = lastName[lastName.length - 1];
        
        if(lastChar === 'a' || lastChar === 'e' || lastChar === 'o' || 
            lastChar === 'u' || lastChar === 'i') {
            idNumber += '8';
        } else {
            idNumber += '7';
        }

        this.idNumber = idNumber;
    }

    addCreditCardInfo(input) {
        this.creditCard = input;
    }

    addDestinationToWishList(destination) {
        if(this.wishList.includes(destination)) {
            throw new Error("Destination already exists in wishlist");
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => {
            return a.length - b.length;
        });
    }

    getVacationerInfo() {
        let output = `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\n`;
        
        output += `ID Number: ${this.idNumber}\n`;
        output += `Wishlist:\n`;

        if(this.wishList.length === 0) {
            output += `empty\n`;
        } else {
            output += `${this.wishList.join(", ")}\n`;
        }

        output += `Credit Card:\n`;
        output += `Card Number: ${this.creditCard.cardNumber}\n`;
        output += `Expiration Date: ${this.creditCard.expirationDate}\n`;
        output += `Security Number: ${this.creditCard.securityNumber}`;

        return output;
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], 
[123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "Zhivk0va"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

