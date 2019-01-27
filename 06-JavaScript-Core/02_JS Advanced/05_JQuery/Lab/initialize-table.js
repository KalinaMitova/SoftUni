function initializeTable() {
    let countries = [
        ['Bulgaria', 'Sofia'],
        ['Germany', 'Berlin'],
        ['Russia', 'Moscow']
    ];

    countries.forEach((country) => {
        createRow(country[0], country[1]);
    });

    fixButtons();

    $('#createLink')
        .click(function() {
            let $newCountryText = $("#newCountryText");
            let $newCapitalText = $("#newCapitalText");

            createRow($newCountryText.val(), $newCapitalText.val());

            fixButtons();
        });

    function createRow(country, capital) {
        let countryTD = $('<td>').text(country);
        let capitalTD = $('<td>').text(capital);    

        let up = $('<a>')
            .attr("href", "#")
            .text("[Up]")
            .click(moveUp);

        let down = $('<a>')
            .attr("href", "#")
            .text("[Down]")
            .click(moveDown);

        let del = $('<a>')
            .attr("href", "#")
            .text("[Delete]")
            .click(deleteRow);

        let actions = $('<td>').append(up, down, del);

        let $row = $('<tr>').append(countryTD, capitalTD, actions);
        $('#countriesTable').append($row);
    }

    function moveUp(ev) {
        let row = ev.target.parentNode.parentNode;
        row.after(row.previousSibling);
        fixButtons();
    }

    function moveDown(ev) {
        let row = ev.target.parentNode.parentNode;
        row.before(row.nextSibling);
        fixButtons();
    }

    function deleteRow(ev) {
        ev.target.parentNode.parentNode.remove();
        fixButtons();
    }

    function fixButtons() {        
        $('#countriesTable tr')
            .slice(2)
            .each((index, element) => {
                let $row = $(element);
                let firstChild = $('#countriesTable tr:nth-child(3)')[0];
                let lastChild = $('#countriesTable tr:last-child')[0];

                let $actions = $row.children().last();
                if ($row[0] == firstChild && $row[0] == lastChild) {
                    $actions.find("a:contains('Up')").css("display", "none");
                    $actions.find("a:contains('Down')").css("display", "none");
                } else if ($row[0] == lastChild) {
                    $actions.find("a:contains('Down')").css("display", "none");
                    $actions.find("a:contains('Up')").css("display", "inline");
                } else if($row[0] == firstChild) {
                    $actions.find("a:contains('Up')").css("display", "none");
                    $actions.find("a:contains('Down')").css("display", "inline");
                } else {
                    $actions.find("a:contains('Up')").css("display", "inline");
                    $actions.find("a:contains('Down')").css("display", "inline");
                }
            });  
    }
}
