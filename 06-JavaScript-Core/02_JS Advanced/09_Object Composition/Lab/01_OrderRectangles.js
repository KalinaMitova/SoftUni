function solve(input) {
    let rectangles = [];

    input.forEach((inputLine) => {
        let rectangle = {
            width: inputLine[0],
            height: inputLine[1],
            area: function() {
                return this.width * this.height;
            },
            compareTo: function(other) {
                return other.area() - this.area() || other.width - this.width;
            }
        };

        rectangles.push(rectangle);
    });

    rectangles
        .sort(function(a, b) {
            return a.compareTo(b);
        });

    return rectangles;
}

let input = [[10,5],[5,12]];

solve(input);