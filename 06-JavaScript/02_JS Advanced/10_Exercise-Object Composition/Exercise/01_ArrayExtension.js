(function() {
    Array.prototype.last = function() {
        let arr = this.valueOf();
        return arr[arr.length - 1];
    };

    Array.prototype.skip = function(n) {
        let currentArr = this.valueOf();

        return currentArr.slice(n);
    }

    Array.prototype.take = function(n) {
        let currentArr = this.valueOf();

        return currentArr.slice(0, n);
    }

    Array.prototype.sum = function() {
        let currentArr = this.valueOf();

        return currentArr.reduce((a, b) => a + b);
    }

    Array.prototype.average = function() {
        let currentArr = this.valueOf();
        let sum = currentArr.reduce((a, b) => a + b);

        return sum / currentArr.length;
    }
})();