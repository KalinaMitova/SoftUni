let assert = require('chai').assert;
let HolidayPackage = require('../HolidayPackage');

describe("Holiday package tests", function() {

    describe("Initialization", function() {
        it('should be instantiated with two parameters', function() {
            // Arrange
            let destination = "shumen";
            let season = "summer";
    
            // Act
            let result = new HolidayPackage(destination, season);
    
            // Assert
            assert.property(result, "destination");
            assert.property(result, "season");
            assert.property(result, "vacationers");
            assert.property(result, "insuranceIncluded");
    
            assert.propertyVal(result, "destination", destination);
            assert.propertyVal(result, "season", season);
            assert.propertyVal(result, "insuranceIncluded", false);
            assert.isEmpty(result.vacationers);
        }); 
    });

    describe("insuranceIncluded", function() {        
        it("should return false for insurance", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";

            // Act
            let result = new HolidayPackage(destination, season);

            // Assert
            assert.isFalse(result.insuranceIncluded);
        });
        
        it("should return true for insurance when its set to true", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";

            // Act
            let result = new HolidayPackage(destination, season);
            result.insuranceIncluded = true;

            // Assert
            assert.isTrue(result.insuranceIncluded);
        });

        it("should throws an error if insurance is set to string", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";

            // Act
            let result = new HolidayPackage(destination, season);
            

            // Assert
            assert.throw(function() {
                result.insuranceIncluded = "true";
            }, Error, "Insurance status must be a boolean");
        });
    });

    describe("addVacationer", function() {
        it("should throws an Error if addVacationer argument is not a string", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = 123;
    
            // Act
            let package = new HolidayPackage(destination, season);
            
    
            // Assert
            assert.throw(function() {
                package.addVacationer(vacantioner);
            }, Error, "Vacationer name must be a non-empty string");
        });
        
        it("should throws an Error if addVacationer argument is an white space string", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = ' ';
    
            // Act
            let package = new HolidayPackage(destination, season);
            
    
            // Assert
            assert.throw(function() {
                package.addVacationer(vacantioner);
            }, Error, "Vacationer name must be a non-empty string");
        });
        
        it("should throws an Error if addVacationer argument is an empty string", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = '';
    
            // Act
            let package = new HolidayPackage(destination, season);
            
    
            // Assert
            assert.throw(function() {
                package.addVacationer(vacantioner);
            }, Error, "Name must consist of first name and last name");
        });
        
        it("should throws an Error if addVacationer argument is an string with more than two names", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = 'Ivan Stoqnov Petrov';
    
            // Act
            let package = new HolidayPackage(destination, season);
            
    
            // Assert
            assert.throw(function() {
                package.addVacationer(vacantioner);
            }, Error, "Name must consist of first name and last name");
        });
        
        it("should throws an Error if addVacationer argument is an string with one name", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = 'Ivan Stoqnov Petrov';
    
            // Act
            let package = new HolidayPackage(destination, season);
            
    
            // Assert
            assert.throw(function() {
                package.addVacationer(vacantioner);
            }, Error, "Name must consist of first name and last name");
        });
        
        it("should add one vacantor for valid name", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioner = 'Ivan Stoqnov';
    
            // Act
            let package = new HolidayPackage(destination, season);
            package.addVacationer(vacantioner);
    
            // Assert
            assert.equal(package.vacationers[0], vacantioner);
            assert.equal(package.vacationers.length, 1);
        });
    });

    describe("showVacationers", function() {
        it("should return message for empty vacantioners array", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
    
            // Act
            let package = new HolidayPackage(destination, season);
            let result = package.showVacationers();

            // Assert
            assert.equal(result, "No vacationers are added yet");
        });

        it("should return message for empty vacantioners array", function() {        
            // Arrange
            let destination = "shumen";
            let season = "summer";
            let vacantioners = ["Ivan Stoqnov", "Petar Mladenov", "Georgi Petrov"];
            let expexted = "Vacationers:\n" + vacantioners.join("\n");

            // Act
            let package = new HolidayPackage(destination, season);
            package.addVacationer(vacantioners[0]);
            package.addVacationer(vacantioners[1]);
            package.addVacationer(vacantioners[2]);

            let result = package.showVacationers();

            // Assert
            assert.equal(result, expexted);
        });
    });

    describe("generateHolidayPackage", function() {
        it("should throw an Error if vacationers are zero", function() {
            // Arrange
            let destination = "shumen";
            let season = "summer";

            // Act
            let package = new HolidayPackage(destination, season);

            // Assert
            assert.throws(function() {
                    package.generateHolidayPackage()
                }, 
                Error, 
                "There must be at least 1 vacationer added");
        });

        it("should return valid text output with 1200 totalPrice, for input [Shumen, Autumn] with three vacationers", function() {
            // Arrange
            let destination = "Shumen";
            let season = "Autumn";
            let vacationers = ["Ivan Stoqnov", "Petar Mladenov", "Georgi Petrov"];
            let expectedTotalPrice = 1200;

            // Act
            let package = new HolidayPackage(destination, season);

            package.addVacationer(vacationers[0]);
            package.addVacationer(vacationers[1]);
            package.addVacationer(vacationers[2]);

            let result = package.generateHolidayPackage();
            let expexted = "Holiday Package Generated\n" +
                            "Destination: " + package.destination + "\n" +
                            package.showVacationers() + "\n" +
                            "Price: " + expectedTotalPrice;

            // Assert
            assert.equal(result, expexted);
        });

        it("should return valid text output with 1300 totalPrice, for input [Shumen, Autumn] with three vacationers and insurance", function() {
            // Arrange
            let destination = "Shumen";
            let season = "Autumn";
            let vacationers = ["Ivan Stoqnov", "Petar Mladenov", "Georgi Petrov"];
            let expectedTotalPrice = 1300;

            // Act
            let package = new HolidayPackage(destination, season);

            package.addVacationer(vacationers[0]);
            package.addVacationer(vacationers[1]);
            package.addVacationer(vacationers[2]);

            package.insuranceIncluded = true;

            let result = package.generateHolidayPackage();
            let expexted = "Holiday Package Generated\n" +
                            "Destination: " + package.destination + "\n" +
                            package.showVacationers() + "\n" +
                            "Price: " + expectedTotalPrice;

            // Assert
            assert.equal(result, expexted);
        });
        
        it("should return valid text output with 1300 totalPrice, for input [Shumen, Autumn] with three vacationers, Summer and insurance", function() {
            // Arrange
            let destination = "Shumen";
            let season = "Summer";
            let vacationers = ["Ivan Stoqnov", "Petar Mladenov", "Georgi Petrov"];
            let expectedTotalPrice = 1500;

            // Act
            let package = new HolidayPackage(destination, season);

            package.addVacationer(vacationers[0]);
            package.addVacationer(vacationers[1]);
            package.addVacationer(vacationers[2]);

            package.insuranceIncluded = true;

            let result = package.generateHolidayPackage();
            let expexted = "Holiday Package Generated\n" +
                            "Destination: " + package.destination + "\n" +
                            package.showVacationers() + "\n" +
                            "Price: " + expectedTotalPrice;

            // Assert
            assert.equal(result, expexted);
        });

        it("should return valid text output with 1300 totalPrice, for input [Shumen, Autumn] with three vacationers, Winter and insurance", function() {
            // Arrange
            let destination = "Shumen";
            let season = "Winter";
            let vacationers = ["Ivan Stoqnov", "Petar Mladenov", "Georgi Petrov"];
            let expectedTotalPrice = 1500;

            // Act
            let package = new HolidayPackage(destination, season);

            package.addVacationer(vacationers[0]);
            package.addVacationer(vacationers[1]);
            package.addVacationer(vacationers[2]);

            package.insuranceIncluded = true;

            let result = package.generateHolidayPackage();
            let expexted = "Holiday Package Generated\n" +
                            "Destination: " + package.destination + "\n" +
                            package.showVacationers() + "\n" +
                            "Price: " + expectedTotalPrice;

            // Assert
            assert.equal(result, expexted);
        });
    });
});