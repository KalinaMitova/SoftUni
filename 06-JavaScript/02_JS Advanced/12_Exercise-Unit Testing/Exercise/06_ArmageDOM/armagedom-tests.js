let expect = require('chai').expect;
let dom = require('jsdom-global')();
let $ = require('jquery');

function nuke (selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
}

describe("nuke tests", function () {
    let $expectedHtml;

    beforeEach(function() {
        document.body.innerHTML = `<!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <title>ArmageDOM</title>
        </head>
        <body>
        <div id="target">
            <div class="nested target">
                <p>This is some text</p>
            </div>
            <div class="target">
                <p>Empty div</p>
            </div>
            <div class="inside">
                <span class="nested">Some more text</span>
                <span class="target">Some more text</span>
            </div>
        </div>
        </body>
        </html>`;

        $expectedHtml = $('body').clone(true, true);
    });

    it("should do nothing when selectors are equal", function () {
        // Arrange
        let selector = '.target';
        let selector2 = '.target';

        // Act
        nuke(selector, selector2);

        // Assert
        expect($expectedHtml.html()).to.be.equal($('body').html());
    });

    it("should do nothing when selector is invalid", function () {
        // Arrange
        let selector1 = '.target';
        let selector2 = 24;

        // Act
        nuke(selector1, selector2);

        // Assert
        expect($expectedHtml.html()).to.be.equal($('body').html());
    });

    it("should do nothing when selector2 does not exist", function () {
        // Arrange
        let selector1 = '.target';

        // Act
        nuke(selector1);

        // Assert
        expect($expectedHtml.html()).to.be.equal($('body').html());
    });

    it("should delete elements with valid selectors", function () {
        // Arrange
        let selector1 = '.target';
        let selector2 = '.valid-selector';

        // Act
        nuke(selector1, selector2);

        // Assert
        expect($expectedHtml.html()).to.be.equal($('body').html());
    });

    it("should delete elements with valid selectors", function () {
        // Arrange
        let selector1 = '.target';
        let selector2 = '.nested';

        // Act
        nuke(selector1, selector2);

        let actual = $('body').html();
        $expectedHtml.find(selector1).filter(selector2).remove();
        let expected = $expectedHtml.html();

        // Assert
        expect(actual).to.be.equal(expected);
    });
});