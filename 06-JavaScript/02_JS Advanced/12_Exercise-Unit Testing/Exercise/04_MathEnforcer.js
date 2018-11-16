let assert = require('chai').assert;
let expect = require('chai').expect;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe("mathEnforcer", function() {
    describe("addFive", function() {
        it("should return undefined for invalid number argument", function() {
            // Arrange
            let input = "some string";

            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for invalid number argument", function() {
            // Arrange
            let input = null;

            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for undefined input", function() {
            // Act
            let actual = mathEnforcer.addFive();

            // Assert
            assert.isUndefined(actual);
        });
        
        it("should return valid result for correct input", function() {
            // Arrange
            let input = 5;
            let expected = 10;

            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct negative number as input", function() {
            // Arrange
            let input = -5;
            let expected = 0;

            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct decimal number as an input", function() {
            // Arrange
            let input = 5.12;
            let expected = 10.12;
            
            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            expect(actual).closeTo(expected, 0.01);
        });
        
        it("should return valid result for negative decimal number as an input", function() {
            // Arrange
            let input = -10.12;
            let expected = -5.12;
            
            // Act
            let actual = mathEnforcer.addFive(input);

            // Assert
            expect(actual).closeTo(expected, 0.01);
        });
    });

    describe("subtractTen", function() {
        it("should return undefined for invalid number argument", function() {
            // Arrange
            let input = "some string";

            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for invalid number argument", function() {
            // Arrange
            let input = null;

            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for undefined input", function() {
            // Act
            let actual = mathEnforcer.subtractTen();

            // Assert
            assert.isUndefined(actual);
        });
        
        it("should return valid result for correct input", function() {
            // Arrange
            let input = 5;
            let expected = -5;

            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct negative number as input", function() {
            // Arrange
            let input = 12;
            let expected = 2;

            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            assert.equal(actual, expected);
        });

        it("should return valid result for correct decimal input", function() {
            // Arrange
            let input = 5.12;
            let expected = -4.88;
            
            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct decimal input", function() {
            // Arrange
            let input = 15.12;
            let expected = 5.12;
            
            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            expect(actual).closeTo(expected, 0.01);
        });

        
        it("should return valid result for negative decimal number as an input", function() {
            // Arrange
            let input = -5.12;
            let expected = -15.12;
            
            // Act
            let actual = mathEnforcer.subtractTen(input);

            // Assert
            expect(actual).closeTo(expected, 0.01);
        });
    });

    describe("sum", function() {
        it("should return undefined for invalid first argument", function() {
            // Arrange
            let firstNumber = "some string";
            let secondNumber = 5;

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for invalid second argument", function() {
            // Arrange
            let firstNumber = 6;
            let secondNumber = "some string";

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.isUndefined(actual);
        });
       
        it("should return undefined for invalid number argument", function() {
            // Arrange
            let firstNumber = null;
            let secondNumber = null;

            // Act
            let actual = mathEnforcer.addFive(firstNumber, secondNumber);

            // Assert
            assert.isUndefined(actual);
        });

        it("should return undefined for invalid second argument", function() {
            // Act
            let actual = mathEnforcer.sum();

            // Assert
            assert.isUndefined(actual);
        });
       
        it("should return valid result for correct positive numbers as an input", function() {
            // Arrange
            let firstNumber = 6;
            let secondNumber = 12;
            let expected = 18;

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct positive decimal numbers as an input", function() {
            // Arrange
            let firstNumber = 60.36;
            let secondNumber = 12.42;
            let expected = 72.78;

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct positive decimal numbers as an input", function() {
            // Arrange
            let firstNumber = -60.36;
            let secondNumber = -12.42;
            let expected = -72.78;

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for correct decimal numbers as an input", function() {
            // Arrange
            let firstNumber = 60.36;
            let secondNumber = -12.42;
            let expected = 47.94;

            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            assert.equal(actual, expected);
        });
        
        it("should return valid result for negative decimal number as an input", function() {
            // Arrange
            let firstNumber = -5.12;
            let secondNumber = -5.12;
            let expected = -10.24;
            
            // Act
            let actual = mathEnforcer.sum(firstNumber, secondNumber);

            // Assert
            expect(actual).closeTo(expected, 0.01);
        });
    });
});