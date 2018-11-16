function solve(input) {
    let pattern = /www\.[A-Za-z0-9\-]+(?:\.[a-z]+)+/g;
    let re = RegExp(pattern);
    let domains = [];
    let m;

    input.forEach(element => {
        do {
            m = re.exec(element);
            if(m) {
                domains.push(m[0]);
            }
        } while(m)
    });

    return domains.join("\n");
}

let result = solve(['Need information about cheap hotels in London?', 
'You can check us at www.london-hotels.co.uk!', 
'We provide the best services in London.', 
'Here are some reviews in some blogs:', 
'"London Hotels are awesome!" - www.indigo.bloggers.com', 
'"I am very satisfied with their services" - ww.ivan.bg', 
'"Best Hotel Services!" - www.rebel21.sedecrem.moc'] 
);

console.log(result);