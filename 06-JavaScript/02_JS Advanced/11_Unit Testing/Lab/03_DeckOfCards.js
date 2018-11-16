function printDeckOfCards(cards) {
    function makeCard(inputFace, inputSuit) {
        let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits = ['S', 'H', 'D', 'C'];
        let outputSuits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        }

        if(!faces.includes(inputFace.toString())) {
            throw new Error("Invalid face");
        }

        if(!suits.includes(inputSuit.toString())) {
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

    let currentCard;

    try {
        let outputCards = [];
    
        cards.forEach((card) => {
            currentCard = card;
            let cardFace = card.slice(0, - 1);
            let cardSuit = card.slice(- 1);

            let resultCard = makeCard(cardFace, cardSuit);

            outputCards.push(resultCard.toString());
        });
        
        console.log(outputCards.join(", "));
    } catch(ex) {
        console.log(`Invalid card: ${currentCard}`);
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);