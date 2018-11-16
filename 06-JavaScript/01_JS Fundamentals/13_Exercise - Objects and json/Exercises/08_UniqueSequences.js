function solve(input) {
    let sequences = input
        .map((lineInput) => {
            let sequence = JSON.parse(lineInput);

            return sequence.sort((a, b) => {
                return b - a;
            });
        })
        .filter((sequence, index, sequences) => {
            for(let i = 0; i < index; i++) {
                if(sequence.length !== sequences[i].length) {
                    continue;
                }
                
                let isEqual = true;
                for (let j = 0; j < sequence.length; j++) {
                    const firstSequenceElement = sequence[j];
                    const secondSequenceElement = sequences[i][j];

                    if(firstSequenceElement !== secondSequenceElement) {
                        isEqual = false;
                        break;
                    }
                }

                if(!isEqual) {
                    continue;
                }

                return false;
            }

            return true;
        })
        .sort((a, b) => {
            return a.length - b.length;
        })
        .map((sequence) => {
            return `[${sequence.join(", ")}]`;
        });

    console.log(sequences.join("\n"));
}

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13, 12, 126]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]);