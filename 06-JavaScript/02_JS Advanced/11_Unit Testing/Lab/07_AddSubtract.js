let assert = require('chai').assert;
let expect = require('chai').expect;

function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

describe.only("createCalculator", function() {

    it("should return object", function() {
        // Act
        let calculator = createCalculator();

        // Assert
        assert.isObject(calculator);
    });
    
    it("should have 'add', 'subtract', 'get' as properties", function() {
        // Arrange
        let keys = ["add", "subtract", "get"];

        // Act
        let calculator = createCalculator();

        // Assert
        expect(calculator).to.have.all.keys(keys);
    });
    
    it("should add number", function() {
        // Arrange
        let firstNumber = 5;
        let secondNumber = 8;
        let expected = 13;

        // Act
        let calculator = createCalculator();
        calculator.add(firstNumber);
        calculator.add(secondNumber);
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should add numbers with decimal points", function() {
        // Arrange
        let firstNumber = 5.5;
        let secondNumber = 8.3;
        let expected = 13.8;

        // Act
        let calculator = createCalculator();
        calculator.add(firstNumber);
        calculator.add(secondNumber);
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should add and subtract number", function() {
        // Arrange
        let firstNumber = 5;
        let secondNumber = 8;
        let expected = -3;

        // Act
        let calculator = createCalculator();
        calculator.add(firstNumber);
        calculator.subtract(secondNumber);
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return 0 for add an array", function() {
        // Arrange
        let input = [];
        let expected = 0;

        // Act
        let calculator = createCalculator();
        calculator.add(input);
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return 0 for subtract an array", function() {
        // Arrange
        let input = [];
        let expected = 0;

        // Act
        let calculator = createCalculator();
        calculator.subtract(input);
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return 0 for no added number", function() {
        // Arrange
        let expected = 0;

        // Act
        let calculator = createCalculator();
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return NaN for invalid number to add", function() {
        // Arrange
        let input = undefined;

        // Act
        let calculator = createCalculator();
        calculator.add(input);
        let actualResult = calculator.get();

        // Assert
        assert.isNaN(actualResult);
    });
    
    it("should return NaN for invalid number to subtract", function() {
        // Arrange
        let input = undefined;

        // Act
        let calculator = createCalculator();
        calculator.subtract(input);
        let actualResult = calculator.get();

        // Assert
        assert.isNaN(actualResult);
    });
    
    it("should return NaN for invalid number to add", function() {
        // Arrange
        let input = "text";

        // Act
        let calculator = createCalculator();
        calculator.add(input);
        let actualResult = calculator.get();

        // Assert
        assert.isNaN(actualResult);
    });
    
    it("should return NaN for invalid number to subtract", function() {
        // Arrange
        let input = "text";

        // Act
        let calculator = createCalculator();
        calculator.subtract(input);
        let actualResult = calculator.get();

        // Assert
        assert.isNaN(actualResult);
    });
    
    it("should return NaN for invalid number to add then subtract", function() {
        // Arrange
        let text = "text";
        let num = -5;

        // Act
        let calculator = createCalculator();
        calculator.add(text);
        calculator.subtract(num);
        let actualResult = calculator.get();

        // Assert
        assert.isNaN(actualResult);
    });
    
    it("should return valid result for add numbers as string", function() {
        // Arrange
        let numberAsString = "15";
        let num = -5;
        let expected = 10;

        // Act
        let calculator = createCalculator();
        calculator.add(numberAsString);
        calculator.add(num)
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return valid result for subtract numbers as string", function() {
        // Arrange
        let numberAsString = "15";
        let num = 5;
        let expected = -20;

        // Act
        let calculator = createCalculator();
        calculator.subtract(numberAsString);
        calculator.subtract(num)
        let actualResult = calculator.get();

        // Assert
        assert.equal(actualResult, expected);
    });
});

