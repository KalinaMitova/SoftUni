let assert = require('chai').assert;

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe("isOddOrEven", function() {

    it("should return undefined for non string arguments", function() {
        // Arrange
        let input = 123;
        
        // Act
        let actualValue = isOddOrEven(input);

        // Assert
        assert.isUndefined(actualValue);
    });
    
    it("should return undefined for null argument", function() {
        // Arrange
        let input = null;
        
        // Act
        let actualValue = isOddOrEven(input);

        // Assert
        assert.isUndefined(actualValue);
    });

    it("should return odd for odd length of string", function() {
        // Arrange
        let input = "123";
        let expected = "odd";

        // Act
        let actualValue = isOddOrEven(input);

        // Assert
        assert.equal(actualValue, expected);
    });
    
    it("should return even for even length of string", function() {
        // Arrange
        let input = "1234";
        let expected = "even";

        // Act
        let actualValue = isOddOrEven(input);

        // Assert
        assert.equal(actualValue, expected);
    });
});
