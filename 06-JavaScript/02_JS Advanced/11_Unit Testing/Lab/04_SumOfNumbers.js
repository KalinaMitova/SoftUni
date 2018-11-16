let assert = require("chai").assert;

function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

describe("sum", function() {

    //sum([1, 2])
    it("should return valid number for valid input", function() {
        //Arrange
        let input = [1, 2];
        let expect = 3;

        //Action
        let actual = sum(input);

        //Assert
        assert.equal(actual, expect);
    });

    //sum([])
    it("should return 0 for empty input array", function() {
        //Arrange
        let input = [];
        let expect = 0;

        //Action
        let actual = sum(input);

        //Assert
        assert.equal(actual, expect);
    });
    
    //sum(undefined)
    it("should throw Error for undefined input", function() {
        //Arrange
        let input = undefined;

        //Assert
        assert.throw(function(){
            
            //Action
            sum(input);
        });
    });
    
    //sum(undefined)
    it("should throw Error for null input", function() {
        //Arrange
        let input = null;

        //Assert
        assert.throw(function(){
            
            //Action
            sum(input);
        });
    });
});