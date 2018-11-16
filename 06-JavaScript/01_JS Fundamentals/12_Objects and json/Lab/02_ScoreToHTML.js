function solve(input) {
    
    let objects = JSON.parse(input);

    let table = `<table>\n\t<tr><th>name</th><th>score</th></tr>\n`;
    objects.forEach(element => {
        table += `\t<tr><td>${escapeHtml(element.name)}</td><td>${element.score}</td></tr>\n`;      
    });
    table += `</table>`

    return table;

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#39;");
    }
}

let table = solve('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');

console.log(table);