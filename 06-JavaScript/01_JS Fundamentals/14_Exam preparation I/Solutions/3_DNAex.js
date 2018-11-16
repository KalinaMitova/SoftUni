function solve(input) {
    let pattern = /^((?:[!@#$?]*[a-z]+[!@#$?]*)+)\=(\d+)\-\-(\d+)<<(\w+)$/;
    let namePattern = /[a-z]+/g;

    let genes = {};

    input.forEach(line => {
        let match = pattern.exec(line);

        if(match) {
            let name = "";
            
            let m;
            do {
                m = namePattern.exec(match[1]);
                if(m) {
                    name += m[0];
                }
            } while(m)

            if(name && name.length === +match[2]){
                let belongs = match[4];

                if(!genes.hasOwnProperty(belongs)) {
                    genes[belongs] = {
                        name,
                        length: +match[2],
                        count: +match[3],
                        belongs: match[4]
                    }
                } else {
                    genes[belongs].count += +match[3];
                }
            }
        }
    });

    Object.keys(genes)
        .sort((a, b) => {
            return genes[b].count - genes[a].count;
        })
        .forEach((gene) => {
            console.log(`${genes[gene].belongs} has genome size of ${genes[gene].count}`);
        });
}

solve(['=12<<cat',
'!vi@rus?=2--142',
'?!cur##viba@cter!!=11--800<<cat',
'!fre?esia#=7--450<<mouse',
'@pa!rcuba@cteria$=13--351<<mouse',
'!richel#ia??=8--900<<human',
'Stop!']);