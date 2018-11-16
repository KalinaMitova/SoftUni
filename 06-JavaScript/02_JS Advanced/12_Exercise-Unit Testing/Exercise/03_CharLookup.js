let assert = require('chai').assert;

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe("lookupChar", function() {

    it("should return undefined for no arguments", function() {
        // Act
        let actualResult = lookupChar();

        // Assert
        assert.isUndefined(actualResult);
    });

    it("should return undefined for invalid arguments", function() {
        // Arrange
        let invalidText = [];
        let validIndex = 5;

        // Act
        let actualResult = lookupChar(invalidText, validIndex);

        // Assert
        assert.isUndefined(actualResult);
    });

    it("should return undefined for invalid arguments", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = "another text";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    it("should return 'Incorrect index' for negative index", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = -1;
        let expected = "Incorrect index";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return 'Incorrect index' for index greater than string length", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = 123;
        let expected = "Incorrect index";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return 'Incorrect index' for index greater than string length", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = validText.length;
        let expected = "Incorrect index";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.equal(actualResult, expected);
    });

    it("should return character in position of passed index", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = 3;
        let expected = "e";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return character in position of passed index", function() {
        // Arrange
        let validText = "some text";
        let invalidIndex = 0;
        let expected = "s";

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    it("should return character in position of passed index", function() {
        // Arrange
        let validText = ['a'];
        let invalidIndex = 0;

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    it("should return character in position of passed index", function() {
        // Arrange
        let validText = "asd";
        let invalidIndex = 5.3;

        // Act
        let actualResult = lookupChar(validText, invalidIndex);

        // Assert
        assert.isUndefined(actualResult);
    });
});