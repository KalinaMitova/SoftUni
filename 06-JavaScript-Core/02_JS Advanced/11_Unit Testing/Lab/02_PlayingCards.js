let assert = require('chai').assert;

function makeCard(inputFace, inputSuit) {
    let faces = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A'];
    let suits = ['S', 'H', 'D', 'C'];
    let outputSuits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    if(!faces.includes(inputFace)) {
        throw new Error("Invalid face");
    }

    if(!suits.includes(inputSuit)) {
        throw new Error("Invalid suit");
    }

    return {
        face: inputFace,
        suits: outputSuits[inputSuit],
        toString: function() {
            return this.face + this.suits;
        }
    }
}

describe("makeCard", function() {
    //makeCard(A, S);
    it("should return valid card for valid inputs", function() {
        //Arrange
        let face = 'A';
        let suit = 'S';
        let expected = 'A\u2660';

        //Action
        let actual = makeCard(face, suit);

        //Assert
        assert.equal(actual, expected, "expected to return A\u2660");
    });

    //makeCard('10', 'H')
    it("should return valid card for valid inputs", function() {
        //Arrange
        let face = 10;
        let suit = 'H';
        let expected = '10\u2665';

        //Action
        let actual = makeCard(face, suit);

        //Assert
        assert.equal(actual, expected, "expected to return 10\u2665");
    });

    //makeCard('1', 'S')
    it("should thrown Error for invalid face", function() {
        //Arrange
        let face = 1;
        let suit = 'S';
        
        //Assert
        assert.throw(function() {

            //Action
            makeCard(face, suit);

        }, "Invalid face");
    }); 
    
    //makeCard('1', 'S')
    it("should thrown Error for invalid suit", function() {
        //Arrange
        let face = 2;
        let suit = 'A';
        
        //Assert
        assert.throw(function() {

            //Action
            makeCard(face, suit);

        }, "Invalid suit");
    }); 
});
