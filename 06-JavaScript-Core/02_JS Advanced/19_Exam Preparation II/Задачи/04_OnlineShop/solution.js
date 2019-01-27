function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);
    
    let productsCount = 0;
    let maxCapacity = 150;
    let totalPrice = 0;

    let product = $('.custom-select');
    let price = $('#price');
    let quantity = $('#quantity');
    let capacity = $('#capacity');
    let sum = $('#sum');

    let submitBtn = $('#submit');
    let display = $('.display');

    product.on('input', function(ev) {
        if($(ev.target).val() === '') {
            submitBtn.prop('disabled', true);
        } else {
            submitBtn.prop('disabled', false);
        }
    });

    submitBtn.on('click', function() {

        if(product.val()) {
            let currentQuantity = +quantity.val()
            productsCount += currentQuantity;
            totalPrice += +price.val() * currentQuantity;
    
            if(productsCount < maxCapacity) {                
                display.append($('<li>')
                    .text(`Product: ${product.val()} Price: ${price.val()} Quantity: ${currentQuantity}`));
            
                capacity.val(productsCount);
                sum.val(totalPrice);  

                resetAll();
            } else {
                capacity
                    .val("full")
                    .addClass("fullCapacity");   
      
                resetAll();
                disableAll();
            }  
        }                   
    });

    function resetAll() {
        product.val(null);
        price.val(1);
        quantity.val(1);
        submitBtn.prop('disabled', true);
    }

    function disableAll() {
        product.prop('disabled', true);
        price.prop('disabled', true);
        quantity.prop('disabled', true);
        submitBtn.prop('disabled', true);
    }
}
