function domSearch(selector, sensitivity) {
    let addContainer = generateAddControl();
    let searchContainer = generateSearchControl();
    let resultContainer = generateResultControl();

    $(selector).append(addContainer, searchContainer, resultContainer);

    function generateAddControl() {
        let container = $('<div>')
            .addClass('add-controls');

        let label = $('<label>')
            .text('Enter text:');

        let input = $('<input>');

        let anchor = $('<a>')
            .text("Add")
            .addClass('button')
            .on("click", addItem);

        label.append(input);
        container.append(label, anchor);

        return container;
    }

    function generateSearchControl() {
        let container = $('<div>')
            .addClass('search-controls');
                
        let label = $('<label>')
            .text('Search:');

        let input = $('<input>')
            .on('input', searchItem);

        label.append(input);
        container.append(label);

        return container;
    }

    function generateResultControl() {
        let container = $('<div>')
            .addClass('result-controls ');

        let list = $('<ul>')
            .addClass('items-list');

        container.append(list);

        return container;
    }

    function addItem(ev) {
        let parent = ev.target.parentElement;

        let inputText = $(parent).find('input').val();

        let strongElement = $('<strong>')
            .text(inputText)

        let anchor = $('<a>')
            .addClass('button')
            .text('X')
            .append(strongElement)
            .on('click', removeElement);

        let item = $('<li>')
            .addClass('list-item')
            .append(anchor, strongElement);

        $('.items-list').append(item);
    }

    function removeElement(ev) {
        ev.target.parentElement.remove();
    }

    function searchItem(ev) {
        let searchText = $(ev.target).val();
        $('.list-item').css('display', 'block');

        

        if(searchText) {
            $('.list-item').each((index, item) => {
                let $item = $(item);
                let text = $item.find('strong').text();

                if(!sensitivity) {
                    searchText = searchText.toLowerCase();
                    text = text.toLowerCase();
                }  

                if(text.indexOf(searchText) === -1) {
                    $item.css('display', 'none');
                }
            });
        }
    }
}
