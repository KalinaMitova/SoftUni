function attachEvents() {
    $('.button')
        .on("click", function() {
            $('.button').removeClass("selected");

            if(!$(this).hasClass("selected")) {
                $(this).addClass("selected");
            }
        });
}