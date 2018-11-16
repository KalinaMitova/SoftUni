class SortedList {
    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(elemenent) {
        this.collection.push(elemenent);
        this.collection.sort((a, b) => a - b);
        this.size += 1;
    }

    remove(index) {
        if(index >= 0 && index < this.collection.length) {
            this.collection.splice(index, 1);
            this.size -= 1;
        }
    }

    get(index) {
        if(index >= 0 && index < this.collection.length) {
            return this.collection[index];
        }
    }
}

let list = new SortedList();

list.add(5);
list.add(6);
list.add(1);
list.add(-41);

list.remove(2);
console.log(list.get(2));
