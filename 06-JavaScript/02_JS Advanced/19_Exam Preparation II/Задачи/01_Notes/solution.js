function addSticker() {
    let title = $('.title');
    let content = $('.content');
    
    if(title.val() !== '' && content.val() !== '') {
        let a = $('<a>')
            .addClass('button')
            .text('x')
            .on('click', function(ev) {
                $(ev.target).parent().remove();
            });

        let h2 = $('<h2>')
            .text(title.val());        
        let hr = $('<hr>');
        let p = $('<p>').text(content.val());

        let li = $('<li>')
            .addClass('note-content')
            .append(a, h2, hr, p);

        $('#sticker-list').append(li);

        title.val(null);
        content.val(null);
    }
}