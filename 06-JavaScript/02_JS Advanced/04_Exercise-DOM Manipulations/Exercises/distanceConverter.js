function attachEventsListeners() {
    let convertBtn = document.getElementById("convert");
    convertBtn.addEventListener("click", calculate);

    function calculate() {
        let inputUnits = document.getElementById("inputUnits");
        let outputUnits = document.getElementById("outputUnits");
        let inputDistance = document.getElementById("inputDistance");
        let outputDistance = document.getElementById("outputDistance");

        let meters = convertToMeters(inputUnits.value, inputDistance.value);
        let result = convertToOutputUnit(outputUnits.value, meters);
        outputDistance.value = result;
    }

    function convertToOutputUnit(outputUnit, distanceInMeters) {
        let curDistance = +distanceInMeters;

        switch (outputUnit) {
            case "km": return curDistance / 1000;
            case "m": return curDistance;
            case "cm": return curDistance * 100;
            case "mm": return curDistance * 1000;
            case "mi": return curDistance / 1609.34;
            case "yrd": return curDistance / 0.9144;
            case "ft": return curDistance / 0.3048;
            case "in": return curDistance / 0.0254;
        }
    }

    function convertToMeters(fromUnit, distance) {
        let curDistance = +distance;
        switch (fromUnit) {
            case "km": return curDistance * 1000;
            case "m": return curDistance;
            case "cm": return curDistance / 100;
            case "mm": return curDistance / 1000;
            case "mi": return curDistance * 1609.34;
            case "yrd": return curDistance * 0.9144;
            case "ft": return curDistance * 0.3048;
            case "in": return curDistance * 0.0254;
        }
    }
}

// 1 km = 1000 m
// 1 m = 1 m
// 1 cm = 0.01 m
// 1 mm = 0.001 m
// 1 mi = 1609.34 m
// 1 yrd = 0.9144 m
// 1 ft = 0.3048 m
// 1 in = 0.0254 m
