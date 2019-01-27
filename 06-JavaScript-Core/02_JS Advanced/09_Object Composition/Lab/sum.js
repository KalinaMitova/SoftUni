function getService(){
    let elements = {};

    function init(selector1, selector2, resultSelector) {
        debugger;        
        elements.firstElement = document.querySelector(selector1);
        elements.secondElement = document.querySelector(selector2);
        elements.resultElement = document.querySelector(resultSelector);
    };

    function add() {
        elements.resultElement.value = +elements.firstElement.value + +elements.secondElement.value;
    };

    function subtract() {
        elements.resultElement.value = +elements.firstElement.value - +elements.secondElement.value;
    };

    return {
        init,
        add,
        subtract
    }
};
    let service = getService();
    service.init("#num1", "#num2", "#result");
    
    document.getElementById("sumButton")
        .addEventListener("click", function() {
            service.add();
        });
    
    document.getElementById("subtractButton")
        .addEventListener("click", function() {
            service.subtract();
        });

