function solve(input) {
    let patterns = [
        /(\*[A-Z][A-Za-z]*)(\t| |$)/g,
        /(\+[0-9\-]{10})(\t| |$)/g,
        /(\![A-Za-z0-9]+)(\t| |$)/g,
        /(\_[A-Za-z0-9]+)(\t| |$)/g];

    let output = input.map(element => {
        patterns.forEach(pattern => {
            element = element.replace(pattern, (m, g1, g2) => {
                return "|".repeat(g1.length) + g2;
            })
        });  
        return element;      
    });

    return output.join("\n");
}

solve(['Agent *Ivankov was in the room when it all happened.*Ivankov', 
'The person in the room was heavily armed.', 
'Agent *Ivankov had to act quick in order.', 
"He picked up his phone and called some unknown number.'] ['I think it was +555-49-796", 
"I can't really remember...", 
'He said something about "finishing work"', 'with subject !2491a23BVB34Q and returning to Base _Aurora21', 
'Then after that he disappeared from my sight.', 
'As if he vanished in the shadows.', 
'A moment, shorter than a second, later, I saw the person flying off the top floor.', 
"I really don't know what happened there.", 
'This is all I saw, that night.', 
'I cannot explain it myself...']
);