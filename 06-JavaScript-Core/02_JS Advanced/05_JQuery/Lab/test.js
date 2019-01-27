$(function() {
    document.body.innerHTML = `
    <table id="countriesTable">
    <tr><th>Country</th><th>Capital</th><th>Action</th></tr>
    <tr><td><input type="text" id="newCountryText" /></td>
        <td><input type="text" id="newCapitalText" /></td>
        <td><a href="#" id="createLink">[Create]</a></td>
    </tr>
    </table>
    `;

    initializeTable();

    // Try to move top element down
    // Setup event
    var clickEvent = document.createEvent('MouseEvents');
    clickEvent.initEvent('click', true, true);
    let table = $('#countriesTable tr');
    $(table[2]).find("a:contains('Down')").get(0).dispatchEvent(clickEvent);

    let expectedTable = [
        ['Germany', 'Berlin', 'Up', 'Down', 'Delete'],
        ['Bulgaria', 'Sofia', 'Up', 'Down', 'Delete'],
        ['Russia', 'Moscow', 'Up', 'Down', 'Delete']
    ];

    // Check table
    table = $('#countriesTable tr');
    for (let i = 0; i< table.length - 2; i++) {
        let  elem = table.eq(i+2);
        for (let j = 0; j < expectedTable[i].length; j++) {
            console.log(elem.text());
            console.log(expectedTable[i][j]);
            console.log($.contains(elem.text(), expectedTable[i][j]));
        }
    }

    // Try to move bottom element up
    $(table[4]).find("a:contains('Up')").get(0).dispatchEvent(clickEvent);

    expectedTable = [
        ['Germany', 'Berlin', 'Up', 'Down', 'Delete'],
        ['Russia', 'Moscow', 'Up', 'Down', 'Delete'],
        ['Bulgaria', 'Sofia', 'Up', 'Down', 'Delete']
    ];

    // Check table
    table = $('#countriesTable tr');
    for (let i = 0; i< table.length - 2; i++) {
        let  elem = table.eq(i+2);
        for (let j = 0; j < expectedTable[i].length; j++) {
            console.log($.contains(elem.text(), expectedTable[i][j]));
        }
    }
});