function initializeTable() {
    let countries = [
        ['Bulgaria', 'Sofia'],
        ['Germany', 'Berlin'],
        ['Russia', 'Moscow']
    ];

    countries.forEach((country) => {
        createRow(country[0], country[1]);
    });

    setButtons();

    $('#createLink')
        .on("click", function() {
            let $newCountryText = $("#newCountryText");
            let $newCapitalText = $("#newCapitalText");

            createRow($newCountryText.val(), $newCapitalText.val());
        });

    function createRow(country, capital) {
        let countryTD = $('<td>').text(country);
        let capitalTD = $('<td>').text(capital);    
        let actions = $('<td>');

        let $row = $('<tr>').append(countryTD, capitalTD, actions);
        $('#countriesTable').append($row);
        setButtons();
    }

    function moveUp(ev) {
        let row = ev.target.parentNode.parentNode;
        row.after(row.previousSibling);
        setButtons();
    }

    function moveDown(ev) {
        let row = ev.target.parentNode.parentNode;
        row.before(row.nextSibling);
        setButtons();
    }

    function deleteRow(ev) {
        ev.target.parentNode.parentNode.remove();
        setButtons();
    }

    function setButtons() {        
        $('#countriesTable tr')
            .slice(2)
            .each((index, element) => {
                let $row = $(element);
                let firstChild = $('#countriesTable tr:nth-child(3)')[0];
                let lastChild = $('#countriesTable tr:last-child')[0];

                let up = $('<a>')
                    .attr("href", "#")
                    .text("[Up]")
                    .on("click", moveUp);

                let down = $('<a>')
                    .attr("href", "#")
                    .text("[Down]")
                    .on("click", moveDown);

                let del = $('<a>')
                    .attr("href", "#")
                    .text("[Delete]")
                    .on("click", deleteRow);

                let $actions = $row.children().last();

                $actions.html("");
                if ($row[0] == firstChild && $row[0] == lastChild) {
                    $actions.append(del);
                } else if ($row[0] == lastChild) {
                    $actions.append(up, del);
                } else if($row[0] == firstChild) {
                    $actions.append(down, del);
                } else {
                    $actions.append(up, down, del);
                }
            });  
    }
}
