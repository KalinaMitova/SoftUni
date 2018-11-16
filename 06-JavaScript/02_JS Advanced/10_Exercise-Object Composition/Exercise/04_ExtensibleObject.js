function solve() {
    let myObj = {
        extend: function (other) {
            let proto = Object.getPrototypeOf(this);

            Object.keys(other)
                .forEach((key) => {
                    if (typeof other[key] === "function") {
                        proto[key] = other[key];
                    } else {
                        this[key] = other[key];
                    }
                });
        }
      }
    
    return myObj;
}

solve();