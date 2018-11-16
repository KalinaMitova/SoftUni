function solve(name, age, weight, height) {

    let personData = {
        name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: getBMI(),
    };

    personData.status = getStatus();

    return personData;

    function getBMI() {
        return Math.round(weight / Math.pow(height / 100, 2));
    }

    function getStatus() {
        if(personData.BMI < 18.5) {
            return "underweight";
        } else if (personData.BMI < 25) {
            return "normal";
        } else if (personData.BMI < 30) {
            return "overweight";
        } else {
            personData.recommendation = "admission required";
            return "obese";
        }
    }
}

console.log(solve("Peter", 29, 75, 182));