function solve(n, k) {
    
    let elements = [1];
    for (let i = 1; i < n; i++) {
        let sumOfPrevNumbers = getSum(elements, i, k);
        elements[i] = sumOfPrevNumbers;
    }
    
    function getSum(elements, currentIndex, k) {
        let sum = 0;
        for (let i = 0; i < k; i++) {
            let index = currentIndex - k + i;
            let element = elements[index];
            if(element !== undefined) {
                sum += element;
            }
        }
        return sum;
    }
    return elements.join(" ");
}

console.log(solve(8, 2));