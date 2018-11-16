(function() {
    let id = 0;
    class Extensible {
        constructor() {
            this.id = id;
            id++;
        }

        extend(template) {
            let proto = Object.getPrototypeOf(this);

            Object.keys(template)
                .forEach((key) => {
                    if (typeof template[key] === "function") {
                        proto[key] = template[key];
                    } else {
                        this[key] = template[key];
                    }
                });
        }
    }

    return Extensible;
})();

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);

let template = {
    extensionMethod: function () {},
    extensionProperty: 'someString'
};

obj1.extend(template);
console.log();