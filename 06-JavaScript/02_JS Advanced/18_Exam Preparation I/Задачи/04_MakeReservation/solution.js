function makeReservation(selector) {
    // Buttons
    let submitBtn = $('#submit');
    let editBtn = $('#edit');
    let continueBtn = $('#continue');

    // Inputs
    let fullName = $('#fullName');
    let email = $('#email');
    let phoneNumber = $('#phoneNumber');
    let address = $('#address');
    let postalCode = $('#postalCode');

    // Other
    let outputElement = $(selector);
    let wrapper = $('#wrapper');
    let infoPreview = $('#infoPreview');
    let information;

    submitBtn.on('click', function() {
        if(fullName.val() && email.val()) {
            information = getInformation();
            setListItems(information);
    
            submitBtn.attr('disabled', 'disabled');
    
            editBtn.removeAttr('disabled');        
    
            continueBtn.removeAttr('disabled');
        }
    });

    editBtn.on('click', function() {
        setInformation(information)
        
        editBtn.attr('disabled', 'disabled');
        continueBtn.attr('disabled', 'disabled');

        submitBtn.removeAttr('disabled');
    });

    
    continueBtn.on('click', function() {
        editBtn.attr('disabled', 'disabled');
        continueBtn.attr('disabled', 'disabled');
        submitBtn.attr('disabled', 'disabled');

        let header = $('<h2>').text('Payment details');

        let select = $('<select>')
            .attr('id', 'paymentOptions')
            .addClass('custom-select')
            .on('change', generatePaymentMethod);

        let choose = $('<option>')
            .attr('selected', 'selected')
            .attr('disabled', 'disabled')
            .attr('hidden', 'hidden')
            .text('Choose');

        let creditCard = $('<option>')
            .val('creditCard')
            .text('Credit Card');
        let bankTransfer = $('<option>')
            .val('bankTransfer')
            .text('Bank Transfer');
        let extraDetails = $('<div>')
            .attr('id', 'extraDetails');

        select.append(choose, creditCard, bankTransfer);
        outputElement.append(header, select, extraDetails);
    });

    function generatePaymentMethod(ev) {
        let target = ev.target;
        debugger;
        if($(target).val() === 'creditCard') {
            $('#extraDetails')
                .html($('<div>')
                    .addClass('inputLabel')
                    .text('Card Number')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<div>')
                    .addClass('inputLabel')
                    .text('Expiration Date')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<div>')
                    .addClass('inputLabel')
                    .text('Security Numbers')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<button>')
                    .attr('id', 'checkOut')
                    .text('Check Out')
                    .on('click', showMessage));

        } else if ($(target).val() === 'bankTransfer') {
            $('#extraDetails')
                .html($('<p>')
                    .html('You have 48 hours to transfer the amount to:<br>IBAN: GR96 0810 0010 0000 0123 4567 890'))
                .append($('<button>')
                    .attr('id', 'checkOut')
                    .text('Check Out')
                    .on('click', showMessage));
        }
    }

    function showMessage() {
        wrapper
            .html($('<h4>')
                .text('Thank you for your reservation!'));
    }

    function setInformation(info) {        
        fullName.val(info.fullName);
        email.val(info.email);
        phoneNumber.val(info.phoneNumber);
        address.val(info.address);
        postalCode.val(info.postalCode);
        infoPreview.text("");
    }

    function setListItems(info) {
        infoPreview
            .append($('<li>').text(`Name: ${info.fullName}`))  
            .append($('<li>').text(`E-mail: ${info.email}`))  
            .append($('<li>').text(`Phone: ${info.phoneNumber}`))  
            .append($('<li>').text(`Address: ${info.address}`))  
            .append($('<li>').text(`Postal Code: ${info.postalCode}`));
    }

    function getInformation() {
        let info = {
            fullName: fullName.val(),
            email: email.val(),
            phoneNumber: phoneNumber.val(),
            address: address.val(),
            postalCode: postalCode.val(),
        };

        fullName.val(null);
        email.val(null);
        phoneNumber.val(null);
        address.val(null);
        postalCode.val(null);

        return info;
    }
}