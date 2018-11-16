function attachEvents() {
    $('#items li')
        .on("click", function() {
            if(!$(this)[0].hasAttribute("data-selected")) {
                $(this)
                    .attr("data-selected", "true")
                    .css("background-color", "#DDD");
            } else {
                $(this)
                    .removeAttr("data-selected")
                    .css("background-color", "initial");
            }
        });

    $('#showTownsButton')
        .on("click", function() {
            let selectedTowns = $('#items li[data-selected]')
                .map((ind, el) => {               
                    return el.textContent
                })
                .toArray()
                .join(", ");

            $('#selectedTowns').text(selectedTowns);
        });
}