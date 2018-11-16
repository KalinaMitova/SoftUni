let assert = require('chai').assert;

function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

describe("rgbToHexColor", function() {

    // rgbToHexColor(1, 2, 3)
    it("should return valid hex color for valid input data", function() {
        // Arrange
        let red = 0;
        let green = 255;
        let blue = 126;
        let expected = "#00FF7E";

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    // rgbToHexColor(1, 2)
    it("should return undefined for invalid blue argument in input", function() {
        // Arrange
        let red = 0;
        let green = 255;

        // Action
        let actualResult = rgbToHexColor(red, green);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(1, 2, undefined)
    it("should return undefined for invalid blue argument in input", function() {
        // Arrange
        let red = 0;
        let green = 255;
        let blue = undefined;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(1, [], 3)
    it("should return undefined for invalid green argument in input", function() {
        // Arrange
        let red = 0;
        let green = [];
        let blue = 3;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor("text", 2, 3)
    it("should return undefined for invalid red argument in input", function() {
        // Arrange
        let red = "text";
        let green = 2;
        let blue = 3;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor()
    it("should return undefined for empty input", function() {
        // Arrange

        // Action
        let actualResult = rgbToHexColor();

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(-1, 0, 0)
    it("should return undefined for negative red", function() {
        // Arrange
        let red = -1;
        let green = 0;
        let blue = 0;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(256, 0, 0)
    it("should return undefined for red up to 255", function() {
        // Arrange
        let red = 256;
        let green = 0;
        let blue = 0;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(0, -1, 0)
    it("should return undefined for negative green", function() {
        // Arrange
        let red = 0;
        let green = -1;
        let blue = 0;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(0, 256, 0)
    it("should return undefined for green up to 255", function() {
        // Arrange
        let red = 0;
        let green = 256;
        let blue = 0;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(0, 0, -1)
    it("should return undefined for negative blue", function() {
        // Arrange
        let red = 0;
        let green = 0;
        let blue = -1;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(0, 0, 256)
    it("should return undefined for blue up to 255", function() {
        // Arrange
        let red = 0;
        let green = 0;
        let blue = 256;

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.isUndefined(actualResult);
    });
    
    // rgbToHexColor(0, 0, 0)
    it("should return valid for black color", function() {
        // Arrange
        let red = 0;
        let green = 0;
        let blue = 0;
        let expected = "#000000";

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.equal(actualResult, expected);
    });
    
    // rgbToHexColor(255, 255, 255)
    it("should return valid for white color", function() {
        // Arrange
        let red = 255;
        let green = 255;
        let blue = 255;
        let expected = "#FFFFFF";

        // Action
        let actualResult = rgbToHexColor(red, green, blue);

        // Assert
        assert.equal(actualResult, expected);
    });
});