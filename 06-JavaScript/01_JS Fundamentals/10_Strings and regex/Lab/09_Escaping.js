function solve(input) {
    let html = "<ul>\n";

    input.forEach(element => {
        let encodedHtml = encode(element);

        html += `  <li>${encodedHtml}</li>\n`
    });

    html += "</ul>";

    return html;

    function encode(html) {
        return html
            .replace(/\&/g, "&amp;")
            .replace(/\</g, "&lt;")
            .replace(/\>/g, "&gt;")
            .replace(/\"/g, "&quot;");
    }
}

solve(['<b>unescaped text</b>', 'normal text']);