const notification = (function() {
    
    const handleError = function(reason) {
        showNotification(reason.responseJSON.description, "errorBox");
    };

    const showNotification = function(message, boxType) {
        $.get('../views/common/notificationBox.hbs')
            .then(function(source) {
                
                let template = Handlebars.compile(source);
                let html = $(template({ message, boxType }));
                
                $('#notifications').html(html);
                
                setTimeout(() => html.fadeOut(), 3000);
            }).catch(function(err) {
                console.log(err)
                if(boxType !== "errorBox") {
                    handleError(err);
                }
            });
    };

    const showInfo = function(message) {
        showNotification(message, "infoBox");
    };

    const showError = function(message) {
        showNotification(message, "errorBox");
    };

    const showLoad = function() {
        showNotification("loading...", "loadingBox");
    };

    const hideLoad = function() {
        let loadingBox = $('#notifications').find("#loadingBox");

        if(!!loadingBox) {
            loadingBox.fadeOut();
        }
    };

    return {
        handleError,
        showInfo,
        showError,
        showLoad,
        hideLoad
    };
}());