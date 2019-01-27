function solve(input) {
    let pattern = /Student name: (\w+), Grade: (\d+), Graduated with an average score: ([\d.]+)/;

    let students = {};

    input.forEach((inputLine) => {
        let match = pattern.exec(inputLine);

        if(match) {
            let name = match[1];
            let grade = +match[2] + 1;
            let averageScore = +match[3];

            if(averageScore >= 3) {
                if(!students.hasOwnProperty(grade)) {
                    students[grade] = {};
                }
    
                if(!students[grade].hasOwnProperty(name)) {
                    students[grade][name] = averageScore;
                }
            }
        }
    });
     
    let gradesKeys = Object.keys(students);

    gradesKeys
        .sort((a, b) => {
            return +a - +b;
        })
        .forEach((grade) => {
            let studentsKeys = Object.keys(students[grade]);
            let averageScore = studentsKeys
                .reduce((acc, cur) => {
                    acc[0] += students[grade][cur];
                    acc[1]++;
                    return acc;
                }, [0, 0])
                .reduce((a, b) => {
                    return (a / b).toFixed(2);
                });

            console.log(`${grade} Grade `);
            console.log(`List of students: ${studentsKeys.join(", ")}`);
            console.log(`Average annual grade from last year: ${averageScore}`);
            console.log();
        });    
}

solve(['Student name: Mark, Grade: 8, Graduated with an average score: 4.75',
        'Student name: Ethan, Grade: 9, Graduated with an average score: 5.66',
        'Student name: George, Grade: 8, Graduated with an average score: 2.83',
        'Student name: Steven, Grade: 10, Graduated with an average score: 4.20',
        'Student name: Joey, Grade: 9, Graduated with an average score: 4.90',
        'Student name: Angus, Grade: 11, Graduated with an average score: 2.90',
        'Student name: Bob, Grade: 11, Graduated with an average score: 5.15',
        'Student name: Daryl, Grade: 8, Graduated with an average score: 5.95',
        'Student name: Bill, Grade: 9, Graduated with an average score: 6.00',
        'Student name: Philip, Grade: 10, Graduated with an average score: 5.05',
        'Student name: Peter, Grade: 11, Graduated with an average score: 4.88',
        'Student name: Gavin, Grade: 10, Graduated with an average score: 4.00']);