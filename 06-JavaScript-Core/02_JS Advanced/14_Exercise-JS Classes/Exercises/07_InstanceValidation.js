class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(val) {
        let pattern = /^\d{6}$/g;

        let match = val.match(pattern);

        if(match) {
            this._clientId = val;
        } else {
            throw new TypeError("Client ID must be a 6-digit number");
        }
    }
    
    get email() {
        return this._email;
    }

    set email(val) {
        let pattern = /^[A-Za-z0-9]+@[a-z\.]+$/g;
        
        let match = val.match(pattern);
        
        if(match) {
            this._email = val;
        } else {
            throw new TypeError("Invalid e-mail");
        }
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(val) {
        if(val.length < 3 || val.length > 20) {
            throw new TypeError("First name must be between 3 and 20 characters long");
        }

        let pattern = /^[A-Za-z]+$/g;

        let match = val.match(pattern);

        if(match) {
            this._firstName = val;
        } else {
            throw new TypeError("First name must contain only Latin characters")
        }
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(val) {
        if(val.length < 3 || val.length > 20) {
            throw new TypeError("Last name must be between 3 and 20 characters long");
        }

        let pattern = /^[A-Za-z]+$/g;

        let match = val.match(pattern);

        if(match) {
            this._lastName = val;
        } else {
            throw new TypeError("Last name must contain only Latin characters")
        }
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')