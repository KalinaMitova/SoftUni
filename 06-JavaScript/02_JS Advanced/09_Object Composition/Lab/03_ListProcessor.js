function solve(input) {
    let service = (function() {
        let collection = [];

        function add(item) {
            collection.push(item);
        }

        function remove(item) {
            collection = collection
                .filter((element) => {
                    return element !== item;
                });
        }

        function print() {
            console.log(collection.join(","));
        }

        return {
            add,
            remove,
            print
        }
    })();

    input.forEach((line) => {
        let tokens = line.split(" ");

        service[tokens[0]](tokens[1]);
    });
}

let input = ['add pesho', 'add gosho', 'add pesho', 'remove pesho','print'];
solve(input);
