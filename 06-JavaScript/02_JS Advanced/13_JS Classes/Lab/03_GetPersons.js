function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            if(firstName) {
                this.firstName = firstName;
            }
            if(lastName) {
                this.lastName = lastName;
            }
            if(age) {
                this.age = age;
            }
            if(email) {
                this.email = email;
            }
        }
    
        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }
    
    let maria = new Person("Maria", "Petrova", 22, "mp@yahoo.com");
    let softuni = new Person("SoftUni");
    let stephan = new Person("Stephan", "Nikolov", 25);
    let peter = new Person("Peter", "Kolev", 24, "ptr@gmail.com");

    return [maria, softuni, stephan, peter];
}

let persons = getPersons();
console.log();