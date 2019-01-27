function getSortedList() {
    let collection = [];

    let obj = Object.create(this);

    obj.size = 0;

    obj.add = function (elemenent) {
        collection.push(elemenent);
        this.size += 1;
        collection.sort((a, b) => a - b);
    }

    obj.remove = function (index) {
        if(index >= 0 && index < collection.length) {
            collection.splice(index, 1);
            this.size -= 1;
        }
    }

    obj.get = function (index) {
        if(index >= 0 && index < collection.length) {
            return collection[index];
        }
    }

    return obj;
}

var myList = getSortedList();

for (let i = 0; i < 10; i++) {
    myList.add(i);
}

myList.remove(9);
console.log(myList.size === 9);
var expectedArray = [0, 1, 2, 3, 4, 5, 6, 7, 8];
// Compare with collection
for (let i = 0; i < expectedArray.length; i++) {
    let curEl = myList.get(i);
    let expEl = expectedArray[i];
    console.log(curEl === expEl);
}