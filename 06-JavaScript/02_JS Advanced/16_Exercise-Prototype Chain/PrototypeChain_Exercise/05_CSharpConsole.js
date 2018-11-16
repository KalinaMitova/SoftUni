let Console = require('./specialConsole');
let assert = require('chai').assert;

describe("Console tests", function() {
    it("should throw an TypeError with message 'No string format given!'", function() {
        // Assert
        assert.throws(Console.writeLine, TypeError, "No string format given!");
    });

    it("should return object in JSON format if argument is an object", function() {
        // Arrange
        let obj = {
            name: "Ivan",
            age: 25
        };

        let expected = JSON.stringify(obj);

        // Act
        let result = Console.writeLine(obj);

        // Assert
        assert.equal(result, expected);
    });

    it("should return same string with placeholders if argument is single string", function() {
        // Arrange
        let str = "Some string with {0} placeholders {1}";

        // Act
        let result = Console.writeLine(str);

        // Assert
        assert.equal(result, str);
    });

    it("should return undefined if argument is single non string", function() {
        // Arrange 
        let num = 55;

        // Act
        let result = Console.writeLine(num);

        // Assert
        assert.isUndefined(result);
    });

    it("should thorws an error if multiple arguments are passed, but the first is not string", function() {
        // Arrange 
        let num = 55;

        // Assert
        assert.throws(function() {
            Console.writeLine(num, num, num);
        }, TypeError, "No string format given!");
    });

    it("should throw RangeError if the number of parameters does not correspond to the number of placeholders", function() {
        // Arrange
        let str = "Some text {0} with {1} placeholders.";
        let arg1 = 22;
        let arg2 = 123;
        let arg3 = "some text";

        // Assert
        assert.throws(function() {
            Console.writeLine(str, arg1, arg2, arg3);
        }, RangeError, "Incorrect amount of parameters given!");
    });

    it("should throw RangeError if the placeholders have indexes not withing the parameters range", function() {
        // Arrange
        let str = "Some text {0} with {12} placeholders.";
        let arg1 = 22;
        let arg2 = 123;

        // Assert
        assert.throws(function() {
            Console.writeLine(str, arg1, arg2);
        }, RangeError, "Incorrect placeholders given!");
    });
    
    it("should return replaced string", function() {
        // Arrange
        let str = "Some text {0} with {1} placeholders.";
        let expected = "Some text 22 with 123 placeholders.";
        let arg1 = 22;
        let arg2 = 123;

        // Act
        let result = Console.writeLine(str, arg1, arg2);

        // Assert
        assert.equal(result, expected);
    });
});