function solve(input) {
    let [sum, min, max, product, join] = input
        .reduce(function(acc, cur) {

            acc[0] += cur;
            acc[1] = Math.min(acc[1], cur);
            acc[2] = Math.max(acc[2], cur);
            acc[3] *= cur;
            acc[4] += cur;

            return acc;            
        }, [0, Number.MAX_VALUE, Number.MIN_VALUE, 1, ""]);

    console.log(`sum = ${sum}`);
    console.log(`min = ${min}`);
    console.log(`max = ${max}`);
    console.log(`product = ${product}`);
    console.log(`join = ${join}`);
}