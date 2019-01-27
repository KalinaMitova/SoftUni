function attachEvents() {
    let weatherSymbols = {
        'sunny': '&#x2600;',
        'partly sunny': '&#x26C5;',
        'overcast': '&#x2601;',
        'rain': '&#x2614;',
        'degrees': '&#176;'        
    };

    $('#submit').on('click', getLocation);

    function getLocation() {
        let locationName = $('#location');
        let locationUrl = 'https://judgetests.firebaseio.com/locations.json';
 
        $('#forecast')
        .empty()
        .append($('<div>')
            .attr('id', 'current'))
        .append($('<div>')
            .attr('id', 'upcoming'));

        $.ajax({
            method: 'GET',
            url: locationUrl
        })
        .then(function(data) {
            let location = data.filter(function(el) {
                return el.name === locationName.val();
            });

            if(location) {
                let code = location[0].code;
                let todayUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
               
                $.ajax({
                    method: 'GET',
                    url: todayUrl
                })
                    .then(function(data) {
                        let div = $('<div>')
                            .text('Current conditions')
                            .addClass('label');

                        let conditionSymbol = $('<span>')
                            .html(weatherSymbols[data.forecast.condition.toLowerCase()])
                            .addClass('condition symbol');

                        let condition = $('<span>')
                            .addClass('condition')
                            .append($('<span>')
                                .addClass('forecast-data')
                                .text(`${location[0].name}, ${location[0].code}`))
                            .append($('<span>')
                                    .addClass('forecast-data')
                                    .html(`${data.forecast.low}${weatherSymbols['degrees']}/${data.forecast.high}${weatherSymbols['degrees']}`))
                                .append($('<span>')
                                    .addClass('forecast-data')
                                    .text(`${data.forecast.condition}`));    

                        $('#forecast').css('display', 'block');
                        $('#current').empty().append(div, conditionSymbol, condition);     

                        let upcomingUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;

                        $.ajax({
                            method: 'GET',
                            url: upcomingUrl
                        })
                            .then(function(upcomingData) {
                                let upcomingElement = $('#upcoming');
                                upcomingElement.empty();

                                upcomingElement
                                    .append($('<div>')
                                        .addClass('label')
                                        .text('Three-day forecast'));
                                upcomingData.forecast.forEach((el) => {                                    
                                    let upcoming = $('<span>')
                                        .addClass('upcoming')
                                        .append($('<span>')
                                            .addClass('symbol')
                                            .html(weatherSymbols[el.condition.toLowerCase()]))
                                        .append($('<span>')
                                            .addClass('forecast-data')
                                            .html(`${el.low}${weatherSymbols['degrees']}/${el.high}${weatherSymbols['degrees']}`))
                                        .append($('<span>')
                                            .addClass('forecast-data')
                                            .text(`${el.condition}`))

                                        upcomingElement.append(upcoming);
                                });
                            })
                            .catch(function() {
                                showError();
                            });
                    })
                    .catch(function() {
                        showError();
                    });                    
            } else {
                showError();
            }
        })
        .catch(function() {
            showError();
        });
    }

    function showError() {
        $('#forecast').show().html("Error");
    }
}