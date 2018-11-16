function addDestination() {
    let inputs = $('#input .inputData');
    debugger;
    let city = inputs[0];
    let country = inputs[1];
    let season = $('#seasons');

    if(city.value !== "" && country.value !== "" && season.val() !== "") {
        let table = $('#destinationsList');

        let tableRow = $('<tr>')
            .append($('<td>')
                .text(`${city.value}, ${country.value}`))
            .append($('<td>')
                .text(season.find(":selected").text()));
    
        table.append(tableRow);
    
        let seasonCounter = $('#' + season.val());
        seasonCounter.val(+seasonCounter.val() + 1);
        
        city.value = null;
        country.value = null;
        season.val("summer");
    
    }    
}