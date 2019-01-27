function solve(input) {
    let service = (function() {
        let objects = {};

        function create(name, parentName) {
            if(parentName) {
                objects[name] = Object.create(objects[parentName]);
            } else {
                objects[name] = {};
            }
        }

        function set(name, key, value) {
            objects[name][key] = value;
        }

        function print(name) {
            let currentObj = objects[name];
            let objectKeyValues = [];

            for (const key in currentObj) {
                objectKeyValues.push(`${key}:${currentObj[key]}`);
            }

            console.log(objectKeyValues.join(", "));
        }

        return {
            create,
            set,
            print
        };
    })();

    input.forEach((element) => {
        let tokens = element.split(" ");

        let action = tokens[0];

        if (action === "create") {
            if(tokens.length === 2) {
                let name = tokens[1];

                service[action](name);
            } else if(tokens.length === 4) {

                let name = tokens[1];
                let parentName = tokens[3];
                
                service[action](name, parentName);
            }
        } else if (action === "set") {
            let name = tokens[1];
            let key = tokens[2];
            let value = tokens[3];

            service[action](name, key, value);
        } else if (action === "print") {
            let name = tokens[1];

            service[action](name);
        }
    });
}

solve(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']);