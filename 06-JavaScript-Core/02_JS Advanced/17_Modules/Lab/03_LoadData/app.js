//Require the data
let data = require('./data');

function sort(property) {
    return data.sort((a, b) => {
        return a[property].localeCompare(b[property]);
    })
}

function filter(property, value) {
    return data.filter((el) => {
        return el[property] === value;
    });
}

result.sort = sort;
result.filter = filter;