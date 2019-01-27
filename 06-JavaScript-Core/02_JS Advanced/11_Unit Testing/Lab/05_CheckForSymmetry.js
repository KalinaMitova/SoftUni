let assert = require('chai').assert;

function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

describe("isSymmetric", function() {

    //isSymmetric([1, 2, 1, 2, 1])
    it("should return true for symetric odd count of elements in array", function() {
        //Arrange
        let input = [1, 2, 1, 2, 1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isTrue(actual);
    });
    
    //isSymmetric([1, 2, 2, 1])
    it("should return true for symetric even count of elements in array", function() {
        //Arrange
        let input = [1, 2, 2, 1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isTrue(actual);
    });
    
    //isSymmetric([1, 2, 3, 1])
    it("should return false for non symetric elements in array", function() {
        //Arrange
        let input = [1, 2, 3, 1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });
    
    //isSymmetric([])
    it("should return false for empty array", function() {
        //Arrange
        let input = [1, 2, 3, 1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });
    
    //isSymmetric(2)
    it("should return false for number as input", function() {
        //Arrange
        let input = 2;

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });
    
    //isSymmetric([1, "someText", {}, "someText", 1])
    it("should return true for different type of elements in array, but symmetric", function() {
        //Arrange
        let input = [1, "someText", {}, "someText", 1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isTrue(actual);
    });
    
    //isSymmetric([1, "someText", {}, "someText", 1])
    it("should return false for different type of elements in array, but non symmetric", function() {
        //Arrange
        let input = [1, "another text", {}, "someText", 1, 5];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });

    //isSymmetric(null)
    it("should return false for null as an input", function() {
        //Arrange
        let input = null;

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });

    //isSymmetric(undefined)
    it("should return false for undefined as an input", function() {
        //Arrange
        let input = undefined;

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });
    
    //isSymmetric([1])
    it("should return true for one element in array", function() {
        //Arrange
        let input = [1];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isTrue(actual);
    });
    
    //isSymmetric([1, "1"])
    it("should return false for different elements in array, but equal by value", function() {
        //Arrange
        let input = [1, '1'];

        //Act
        let actual = isSymmetric(input);

        //Assert
        assert.isFalse(actual);
    });
});