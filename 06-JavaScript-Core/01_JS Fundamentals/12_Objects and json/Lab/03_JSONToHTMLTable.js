function solve(input) {
    let objs = JSON.parse(input);
    let keys = Object.keys(objs[0]);

    let table = "<table>";
    table += getHeader(keys);    
    table += getBody(objs);
    table += "\n</table>"

    return table;

    function getBody(objects) {
        let body = "";
        objects.forEach(obj => {
            body += "\n\t<tr>";

            keys.forEach((key) => {
                let element = typeof obj[key] == "string" ? escapeHtml(obj[key]) : obj[key];
                body += `<td>${element}</td>`;
            });

            body += "</tr>";
        });

        return body;
    }

    function getHeader(keys) {
        let head = "\n\t<tr>"
        keys.forEach(element => {
            head += `<th>${element}</th>`;
        });
        head += "</tr>";

        return head;
    }

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#39;");
    }
}

solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');