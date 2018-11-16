function solve(input) {

    let html = '<table>\n';

    input.forEach((employeeData) => {
        let employee = JSON.parse(employeeData);

        html += '\t<tr>\n';
        html += `\t\t<td>${escapeHtml(employee.name)}</td>\n`;
        html += `\t\t<td>${escapeHtml(employee.position)}</td>\n`;
        html += `\t\t<td>${employee.salary}</td>\n`;
        html += '\t<tr>\n';
    });

    html += '</table>';

    return html;

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#39;");
    }
}

let result = solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
                    '{"name":"Teo","position":"Lecturer","salary":1000}',
                    '{"name":"Georgi","position":"Lecturer","salary":1000}']);

console.log(result);