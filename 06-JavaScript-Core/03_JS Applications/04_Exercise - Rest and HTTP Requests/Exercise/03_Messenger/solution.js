function attachEvents() {
    let baseUrl = `https://messenger-6bf89.firebaseio.com/messenger`;

    let messages = $('#messages');
    let authorInput = $('#author');
    let contentInput = $('#content');
    let sendBtn = $('#submit');
    let refreshBtn = $('#refresh');

    sendBtn.on('click', sendMessage);
    refreshBtn.on('click', showAllMessages);

    showAllMessages();
    
    function sendMessage() {        
            let message = {
                author: authorInput.val(),
                content: contentInput.val(),
                timestamp: +Date.now()
            };

            console.log(message);

            let request = {
                url: baseUrl + '.json',
                method: "POST",
                data: JSON.stringify(message),
                success: function() {},
                error: function(er) {
                    console.log(er);
                }
            };

            $.ajax(request).then(showAllMessages);
        

        contentInput.val("");
    }

    function showAllMessages() {
        let request = {
            url: baseUrl + '.json',
            method: "GET",
            success: displayMessages,
            error: function(er) {
                console.log(er);
            }
        };

        $.ajax(request);
    }

    function displayMessages(data) {
        messages.html("");

        Object.keys(data)
            .sort((a, b) => {
                return data[a].timestamp - data[b].timestamp;
            })
            .forEach((item) => {
                messages.append(`${data[item].author}: ${data[item].content}\n`);
            });
    }
}