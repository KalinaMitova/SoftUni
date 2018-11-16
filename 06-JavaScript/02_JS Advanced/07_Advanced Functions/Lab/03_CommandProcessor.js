function solve(input) {
    let obj = {
        content: "",
        append: function(str) {
            this.content += str;
        }, 
        removeStart: function(index) {
            this.content = this.content.slice(index);
        },
        removeEnd: function(index) {
            this.content = this.content.slice(0, this.content.length - index);
        },
        print: function() {
            console.log(this.content)
        },
        execute: function(input) {
            input.forEach((inputLine) => {
                let tokens = inputLine.split(" ");
                let command = tokens[0];
                let args = tokens[1];
                
                this[command].call(this, args);
            });
        }
    };

    obj.execute(input);
}

solve(['append 123',
'append 45',
'removeStart 2',
'removeEnd 1',
'print']);