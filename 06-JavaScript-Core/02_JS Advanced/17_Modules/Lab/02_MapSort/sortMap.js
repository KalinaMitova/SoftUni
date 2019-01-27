function mapSort(map, sortFn) {    
    if(sortFn) {
        return new Map([...map.entries()].sort(sortFn));
    }

    return new Map([...map.entries()].sort((a, b) => {
        return a[0] > b[0];
    }));
}

module.exports = mapSort;