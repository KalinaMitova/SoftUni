function solve(input) {

    let xml = '<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n';

    for (let i = 0; i < input.length; i+=2) {
        let question = input[i];
        let answer = input[i + 1];
        
        xml += generateXmlTag("question", question);
        xml += generateXmlTag("answer", answer);
    }

    xml += "</quiz>";

    return xml;

    function generateXmlTag(element, text) {
        return `  <${element}>\n    ${text}\n  </${element}>\n`;
    }
}

console.log(solve(["Dry ice is a frozen form of which gas?", 
    "Carbon Dioxide", 
    "What is the brightest star in the night sky?",
    "Sirius"]));