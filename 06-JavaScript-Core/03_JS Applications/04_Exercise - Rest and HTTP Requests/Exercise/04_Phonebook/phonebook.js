function attachEvents() {
    $('#btnLoad').on('click', loadContacts);
    $('#btnCreate').on('click', createContact);
    let baseServiceUrl = `https://phonebook-a7976.firebaseio.com/phonebook`;

    function loadContacts() {
        $.get(baseServiceUrl + '.json')
            .then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contacts) {
        $('#phonebook').empty();
        for (const key in contacts) {
            let person = contacts[key]['person'];
            let phone = contacts[key]['phone'];
            let li = $('<li>')
                .text(`${person}: ${phone} `);

            let button = $('<button>')
                .text('Delete')
                .on('click', deleteContact.bind(this, key));

            li.append(button)
            $('#phonebook').append(li);
        }
    }
    
    function displayError(err) {
        $('#phonebook').append(`<li>Error</li>`)
    }

    function createContact() {
        let person = $('#person');
        let phone = $('#phone');
                
        if(person.val() && phone.val()) {           
            let data = JSON.stringify({ "person": person.val(), "phone": phone.val() });    
            $.post(baseServiceUrl + '.json', data)
                .then(loadContacts)
                .catch(displayError);
        }
    
        person.val("");
        phone.val("");
    }
    
    function deleteContact(key) {
        let request = {
            method: 'DELETE',
            url: baseServiceUrl + `/${key}.json`
        };

        $.ajax(request)
            .then(loadContacts)
            .catch(displayError);
    }    
 }
 
 attachEvents();