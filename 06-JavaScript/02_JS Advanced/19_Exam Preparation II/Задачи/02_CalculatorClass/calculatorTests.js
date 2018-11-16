let assert = require('chai').assert;
let expect = require('chai').expect;
let Calculator = require('./Calculator');

describe("Calculator", function() {
    let calculator;

    this.beforeEach(function() {
        calculator = new Calculator();
    });

    it("should initialize property 'expenses' with empty array", function() {
        assert.property(calculator, 'expenses');
        assert.isEmpty(calculator.expenses);
        assert.isArray(calculator.expenses);
    });

    it("should add item when add method called", function() {
        calculator.add(10);
        calculator.add("pesho");
        calculator.add({});
        calculator.add(2.5);
        
        assert.deepEqual(calculator.expenses, [10, "pesho", {}, 2.5]);
    });
    
    it("should return message 'Cannot divide by zero' ", function() {        
        calculator.add(10);
        calculator.add("pesho");
        calculator.add(0);

        let result = calculator.divideNums();

        assert.equal(result, "Cannot divide by zero");
    });

    it("should divide numbers in calculator", function() {        
        calculator.add(10);
        calculator.add("pesho");
        calculator.add(1.5);

        let result = calculator.divideNums();

        expect(result).to.be.closeTo(6.66, 0.01);
    });

    it("should throws error if array not contains numbers", function() {        
        calculator.add("10");
        calculator.add("pesho");
        calculator.add(true);

        assert.throws(function() {
            calculator.divideNums();
        }, Error, "There are no numbers in the array!");
    });

    it("should return items with ' -> ' joined", function() {        
        calculator.add(10);
        calculator.add(5);
        calculator.add("pesho");
        calculator.add(1.5);

        let result = calculator.toString();
        let expected = "10 -> 5 -> pesho -> 1.5";

        assert.equal(result, expected);
    });
    
    it("should return 'empty array' message ", function() {
        let result = calculator.toString();
        let expected = "empty array";
        
        assert.equal(result, expected);
    });
    
    it("should return oredered numbers joined with ', ' ", function() {
        calculator.add(10);
        calculator.add(1.6);
        calculator.add(-22);
        calculator.add(0);
        
        let result = calculator.orderBy();
        let expected = "-22, 0, 1.6, 10";

        assert.equal(result, expected);
    });
    
    it("should return oredered mixed data joined with ', ' ", function() {
        calculator.add(10);
        calculator.add(1.6);
        calculator.add(-22);
        calculator.add(0);
        
        let result = calculator.orderBy();
        let expected = "-22, 0, 1.6, 10";

        assert.equal(result, expected);
    });

    it("should return oredered mixed data joined with ', ' ", function() {
        let arr = [10, "1.6", [], true, 0, 2.5];
        calculator.add(arr[0]);
        calculator.add(arr[1]);
        calculator.add(arr[2]);
        calculator.add(arr[3]);
        calculator.add(arr[4]);
        calculator.add(arr[5]);
        
        let result = calculator.orderBy();
        let expected = arr.sort().join(', ');

        assert.equal(result, expected);
    });

    it("should return 'empty' message for empty array", function() {        
        let result = calculator.orderBy();
        let expected = "empty";

        assert.equal(result, expected);
    });
});