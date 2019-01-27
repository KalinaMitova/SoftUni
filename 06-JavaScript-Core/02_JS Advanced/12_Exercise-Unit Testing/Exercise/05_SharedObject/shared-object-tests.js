let dom = require('jsdom')();
let assert = require('chai').assert;
let expect = require('chai').expect;
$ = require('jquery');
let sharedObject = require('./shared-object');

describe('sharedObject tests', function () {
    beforeEach(function () {
        document.body.innerHTML = `'<!DOCTYPE html>\n' +
        '<html lang="en">\n' +
        '<head>\n' +
        '    <meta charset="UTF-8">\n' +
        '    <title>Shared Object</title>\n' +
        '</head>\n' +
        '<body>\n' +
        '    <div id="wrapper">\n' +
        '        <input type="text" id="name">\n' +
        '        <input type="text" id="income">\n' +
        '    </div>\n' +
        '    <script src="shared-object.js"></script>\n' +
        '</body>\n' +
        '</html>\n'`;
    });

    describe("test properties default value", function () {
        it("property 'name' should be null", function () {
            let inputName = $('#name').val();

            assert.isNull(sharedObject.name);
            assert.isEmpty(inputName);
        });

        it("property 'income' should be null", function () {
            let inputIncome = $('#income').val();
            assert.isNull(sharedObject.income);
            assert.isEmpty(inputIncome);
        });
    });

    describe("test changeName function in object", function () {

        it("should do nothing when empty string is passed as argument", function () {
            // Arrange
            let input = "";
            let name = "%pesho_";
            let nameElement = $('#name');

            nameElement.val(name);
            sharedObject.name = name;

            // Act
            sharedObject.changeName(input);
            let actualElementValue = nameElement.val();

            // Assert
            assert.equal(sharedObject.name, name);
            assert.equal(actualElementValue, name);
        });

        it("should change name when valid name is passed as argument", function () {
            // Arrange
            let input = "asdf";

            // Act
            sharedObject.changeName(input);
            let actual = $('#name').val();

            // Assert
            assert.equal(sharedObject.name, input);
            assert.equal(actual, input);
        });
    });

    describe("test changeIncome function in object", function () {

        it("should do nothing when invalid input is passed as argument", function () {
            // Arrange
            let income = 120;
            let input = "wrong input";
            let incomeElement = $('#income');

            incomeElement.val(income);
            sharedObject.income = income;

            // Act
            sharedObject.changeIncome(input);

            // Assert
            let actualIncomeValue = incomeElement.val();
            assert.equal(sharedObject.income, income);
            assert.equal(actualIncomeValue, income);
        });

        it("should do nothing when negative number is passed as argument", function () {
            // Arrange
            let input = -1;
            let income = 120;
            let incomeElement = $('#income');

            incomeElement.val(income);
            sharedObject.income = income;

            // Act
            sharedObject.changeIncome(input);

            // Assert
            let actualIncomeValue = incomeElement.val();

            assert.equal(sharedObject.income, income);
            assert.equal(actualIncomeValue, income);
        });

        it("should do nothing when zero number is passed as argument", function () {
            // Arrange
            let input = 0;
            let income = 120;
            let incomeElement = $('#income');

            incomeElement.val(income);
            sharedObject.income = income;

            // Act
            sharedObject.changeIncome(input);

            // Assert
            let actualIncomeValue = incomeElement.val();

            assert.equal(sharedObject.income, income);
            assert.equal(actualIncomeValue, income);
        });

        it("should do nothing when decimal number is passed as argument", function () {
            // Arrange
            let input = 50.36;
            let income = 120;
            let incomeElement = $('#income');

            incomeElement.val(income);
            sharedObject.income = income;

            // Act
            sharedObject.changeIncome(input);

            // Assert
            let actualIncomeValue = incomeElement.val();

            assert.equal(sharedObject.income, income);
            assert.equal(actualIncomeValue, income);
        });

        it("should change income when integer number is passed as argument", function () {
            // Arrange
            let input = 500;

            // Act
            sharedObject.changeIncome(input);
            let actual = $('#income').val();

            // Assert
            assert.equal(sharedObject.income, input);
            assert.equal(actual, input);
        });
    });

    describe("test updateName function in object", function () {

        it("should do nothing when input textbox with id=name is empty", function () {
            // Arrange
            let nameElement = $('#name');
            let name = "%pesho";

            nameElement.val("");
            sharedObject.name = name;

            // Act
            sharedObject.updateName();

            // Assert
            assert.equal(sharedObject.name, name);
        });

        it("should change name when input textbox with id=name have correct value", function () {
            // Arrange
            let inputName = "Ivan Ivanov Stoqnov";
            let name = $('#name');
            name.val(inputName);
            sharedObject.name = "%Petran";

            // Act
            sharedObject.updateName();

            // Assert
            assert.equal(sharedObject.name, inputName);
        });
    });

    describe("test updateIncome function in object", function () {

        it("should do nothing when input textbox with id=income is empty", function () {
            // Arrange
            let incomeElement = $('#income');
            let income = 120;
            incomeElement.val("");
            sharedObject.income = income;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, income);
        });

        it("should do nothing when input textbox with id=income is with text value", function () {
            // Arrange
            let incomeElement = $('#income');
            let income = 120;
            incomeElement.val("text");
            sharedObject.income = income;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, income);
        });

        it("should do nothing when input textbox with id=income is with NaN value", function () {
            // Arrange
            let incomeElement = $('#income');
            let income = 120;
            incomeElement.val(NaN);
            sharedObject.income = income;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, income);
        });

        it("should do nothing when input textbox with id=income is negative number", function () {
            // Arrange
            let incomeElement = $('#income');
            let income = 120;
            incomeElement.val(-15);
            sharedObject.income = income;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, income);
        });

        it("should do nothing when input textbox with id=income is zero", function () {
            // Arrange
            let incomeElement = $('#income');
            let income = 120;
            incomeElement.val(0);
            sharedObject.income = income;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, income);
        });

        it("should do nothing when input textbox with id=income is decimal number", function () {
            // Arrange
            let oldValue = 16;
            let newValue = 116.36;
            let incomeElement = $('#income');
            incomeElement.val(newValue);
            sharedObject.income = oldValue;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, oldValue);
        });

        it("should change value when input textbox with id=income is valid positive integer", function () {
            // Arrange
            let incomeElement = $('#income');
            let oldValue = 116;
            let newValue = 220;
            incomeElement.val(newValue);
            sharedObject.income = oldValue;

            // Act
            sharedObject.updateIncome();

            // Assert
            assert.equal(sharedObject.income, newValue);
        });
    });
});