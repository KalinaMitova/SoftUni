class Point{
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2) {
        let sideA = Math.max(p1.x, p2.x) - Math.min(p1.x, p2.x);
        let sideB = Math.max(p1.y, p2.y) - Math.min(p1.y, p2.y);

        return Math.sqrt(Math.pow(sideA, 2) + Math.pow(sideB, 2));
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
