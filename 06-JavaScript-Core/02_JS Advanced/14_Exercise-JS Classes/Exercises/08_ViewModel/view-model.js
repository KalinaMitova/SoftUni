class Textbox {

    constructor(selector, regex) {
        this._elements = $(selector);
        this._invalidSymbols = regex;

        let self = this;
        this._elements.on('input', function() {
            self.value = this.value;            
        });
    }

    get value() {
        return this._value;
    }

    set value(val) {
        this._value = val;

        this.elements.val(val);
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        return this.value.match(this._invalidSymbols) === null;
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);

let inputs = $('.textbox');

inputs.on('input',function(){console.log(textbox.value);});
