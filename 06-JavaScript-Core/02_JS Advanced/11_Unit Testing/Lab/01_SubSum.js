let assert = require("chai").assert;

function subsum(arr, startIndex, endIndex) {
    if(!Array.isArray(arr)) {
        return NaN;
    }

    if(startIndex < 0) {
        startIndex = 0;
    }

    if(endIndex >= arr.length) {
        endIndex = arr.length - 1;
    }

    let sum = 0;

    if(startIndex < arr.length && endIndex >= 0) {
        for (let index = startIndex; index <= endIndex; index++) {
            const element = arr[index];
            sum += +element;
        }
    }

    return sum;
}

describe('subsum', function() {
    // subsum([10, 20, 30, 40, 50, 60], 3, 300)
    it("should return valid number for valid input", function(){ 
        let arr = [10, 20, 30, 40, 50, 60];
        let startIndex = 3;
        let endIndex = 300;

        let result = subsum(arr, startIndex, endIndex);

        assert.equal(result, 150, "Expect to return valid sum of numbers.");
    });

    // subsum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1)
    it("should return valid number for valid input", function() {
        let arr = [1.1, 2.2, 3.3, 4.4, 5.5];
        let startIndex = -3;
        let endIndex = 1;

        let result = subsum(arr, startIndex, endIndex);

        assert.closeTo(result, 3.3, 3.3, "Expect to return valid sum of numbers.");
    });

    // subsum([10, 'twenty', 30, 40], 0, 2)
    it("should return NaN for invalid element in array", function() {
        let arr = [10, 'twenty', 30, 40];
        let startIndex = 0;
        let endIndex = 2;

        let result = subsum(arr, startIndex, endIndex);

        assert.isNaN(result, "Expect to return NaN.");
    });

    //subsum([], 1, 2)
    it("should return 0 for empty array", function() {
        let arr = [];
        let startIndex = 1;
        let endIndex = 2;

        let result = subsum(arr, startIndex, endIndex);

        assert.equal(result, 0, "Expect to return 0.");
    });

    //subsum('text', 0, 2)
    it("should return NaN for invalid input of array", function() {
        let arr = 'text';
        let startIndex = 0;
        let endIndex = 2;

        let result = subsum(arr, startIndex, endIndex);

        assert.isNaN(result, "Expect to return NaN");
    });
});