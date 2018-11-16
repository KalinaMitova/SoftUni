(() => {
    String.prototype.ensureStart = function(str) {
        let newString = this.valueOf();

        if(newString.startsWith(str)) {
            return newString;
        }

        return str + newString;
    }

    String.prototype.ensureEnd = function(str) {
        let newString = this.valueOf();

        if(newString.endsWith(str)) {
            return newString;
        }

        return newString + str;
    }

    String.prototype.isEmpty = function() {
        return this.valueOf() === "";
    }

    String.prototype.truncate = function(n) {
        let val = this.valueOf();
        let length = val.length;

        if(n < 4) {
            return '.'.repeat(n);
        }

        if(length <= n) {
            return val;
        }

        let tokens = val.split(" ");

        if(tokens.length === 1) {
            return val.slice(0, n - 3) + "...";
        }

        let tokensLength = 0;
        let newWords = tokens.filter((el, index) => {
            
            if(index !== 0 && index !== tokens.length - 1) {
                tokensLength += 1;
            }

            tokensLength += el.length;

            return tokensLength + 3 <= n;
        })

        return newWords.join(" ") + "...";        
    }

    String.format = function(str, ...params) {
        return str.replace(/{(\d+)}/g, function(str, group) {
            
            if (params[+group]){
                return params[+group];
            }

            return str;
        });
    }
})();

var testString = 'the quick brown fox jumps over the lazy dog';

testString = testString.truncate(43);
testString = testString.truncate(45);