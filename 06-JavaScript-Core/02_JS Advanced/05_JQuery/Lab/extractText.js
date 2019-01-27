function extractText() {
    let items = $('#items li')
        .map((index, item) => item.textContent)
        .toArray()
        .join(", ");
    $('#result').text(items);
}