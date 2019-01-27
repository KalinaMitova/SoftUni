function solve(input) {
    let pattern = /^([A-Z][a-zA-Z]*) - ([1-9]\d*) - ([a-zA-Z\d -]+)$/;

    let re = RegExp(pattern);
    let m;
    let employees = [];
    
    input.forEach(element => {
        m = re.exec(element);
        if(m) {
            let employee = {
                name: m[1],
                salary: m[2],
                position: m[3]
            };

            employees.push(employee);
        }
    });

    employees.forEach(employee => {
        let output = `Name: ${employee.name}\nPosition: ${employee.position}\nSalary: ${employee.salary}`;
        console.log(output);
    });
}

solve(['Jonathan - 2000 - Manager',
'Peter- 1000- Chuck',
'George - 1000 - Team Leader'] 
);