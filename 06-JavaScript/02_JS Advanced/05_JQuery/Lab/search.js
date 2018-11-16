//"<matches> matches found.
function search() {
    let searchText = $('#searchText').val();

    let towns = $('#towns li')
        .each((i, item) => {
            item.style.fontWeight = "normal";
        })
        .filter((index, item) => {
            return item.textContent.indexOf(searchText) > -1;
        })
        .each((index, item) => {
            item.style.fontWeight = "bold";
        });

    $('#result').text(`${towns.length} matches found.`);
}