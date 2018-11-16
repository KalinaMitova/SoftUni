function getArticleGenerator(articles) {
    let index = 0;
    let length = articles.length;

    return function() {
        if(index < length) {
            $('#content')
                .append(
                    $('<article>')
                    .css('border', '2px solid blue')
                    .text(articles[index]));
            index += 1;
        }
    }    
}
