solve([-1, -2, 3.5, 0, 0, 2]);

function solve(input) {

    let x1 = +input[0];
    let y1 = +input[1];
    let x2 = +input[2];
    let y2 = +input[3];
    let x3 = +input[4];
    let y3 = +input[5];

    let paths = [
        getDistance(x1, y1, x2, y2, 1, 2),
        getDistance(x2, y2, x3, y3, 2, 3),
        getDistance(x3, y3, x1, y1, 3, 1)
    ];

    let bestPath = getSmallestPath(paths);

    printResult(bestPath);

    function printResult(bestPath) {
        let a, 
            b, 
            c;

        if (bestPath.pathA.startPoint == bestPath.endPoint) {
            a = Math.min(bestPath.pathB.startPoint, bestPath.pathA.endPoint);
            b = bestPath.pathB.endPoint;
            c = Math.max(bestPath.pathB.startPoint, bestPath.pathA.endPoint);
        }
        else {
            a = Math.min(bestPath.pathA.startPoint, bestPath.pathB.endPoint);
            b = bestPath.pathA.endPoint;
            c = Math.max(bestPath.pathA.startPoint, bestPath.pathB.endPoint);
        }

        console.log(`${a}->${b}->${c}: ${bestPath.totalDistance}`);
    }

    function getSmallestPath(paths) {

        let bestPaths = [
            paths[0],
            paths[1]
        ];

        let totalDistance = paths[0].distance + paths[1].distance;

        if(totalDistance > paths[1].distance + paths[2].distance){
            bestPaths = [
                paths[1],
                paths[2]
            ];

            totalDistance = paths[1].distance + paths[2].distance;
        }
    
        if(totalDistance > paths[2].distance + paths[0].distance) {
            bestPaths = [
                paths[2],
                paths[0]
            ];

            totalDistance = paths[2].distance + paths[0].distance;
        }

        return {
            totalDistance,
            pathA: bestPaths[0],
            pathB: bestPaths[1]
        };
    }

    function getDistance(x1, y1, x2, y2, startPoint, endPoint) {
        let sidaA = Math.abs(x1 - x2);
        let sideB = Math.abs(y1 - y2);

        let distance = Math.sqrt(Math.pow(sidaA, 2) + Math.pow(sideB, 2));

        let path = {
            startPoint: startPoint,
            endPoint: endPoint,
            distance: distance
        };

        return path;
    }
}