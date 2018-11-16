function increment(element) {
    let textarea = $("<textarea>")
        .attr("disabled", "disabled")
        .addClass("counter")
        .val(0);

    let incrementBtn = $("<button>")
        .addClass("btn")
        .attr("id", "incrementBtn")
        .text("Increment")
        .on("click", incrementValue);

    let addBtn = $("<button>")
        .addClass("btn")
        .attr("id", "addBtn")
        .text("Add")
        .on("click", addElement);

    let ul = $("<ul>")
        .addClass("results");

    $(element).append(textarea, incrementBtn, addBtn, ul);
    
    function incrementValue() {
        let counter = $(".counter").val();
        counter++;
        $(".counter").val(counter);
    }

    function addElement() {
        let counter = $(".counter").val();
        let li = $("<li>")
            .text(counter);

        $(".results").append(li);
    }
}
