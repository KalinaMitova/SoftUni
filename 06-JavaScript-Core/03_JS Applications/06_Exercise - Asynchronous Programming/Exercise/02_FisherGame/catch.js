function attachEvents() {
    let catches = $('#catches');

    $('button.load').on('click', listAll);
    $('button.add').on('click', createCatch);

    function listAll() {
        let listAllUrl = `https://baas.kinvey.com/appdata/kid_ByvVKgnCQ/biggestCatches`;
    
        $.ajax({
            method: 'GET',
            url: listAllUrl,
            headers: {
                authorization: 'Basic ' + global.btoa('ruskov:123456')
            }
        })
        .then(function(data) {
            catches.empty();

            data.forEach((element) => {
                let catchElement = createElement(element);
                catches.append(catchElement);
            });
        })
        .catch((err) => console.log(err));
    }

    function createCatch() {
        let createUrl = `https://baas.kinvey.com/appdata/kid_ByvVKgnCQ/biggestCatches`;
    
        let angler = $('#addForm .angler').val();
        let weight = $('#addForm .weight').val();
        let species = $('#addForm .species').val();
        let location = $('#addForm .location').val();
        let bait = $('#addForm .bait').val();
        let captureTime = $('#addForm .captureTime').val();

        if(angler, weight, species, location, bait, captureTime) {
            $.ajax({
                method: 'POST',
                url: createUrl,
                headers: {
                    authorization: 'Basic ' + global.btoa('ruskov:123456'),
                    contentType: 'application/json'
                },
                data: JSON.stringify({                    
                    angler,
                    weight,
                    species,
                    location,
                    bait,
                    captureTime
                })
            })
            .then(function(data) {
                let catchElement = createElement(data);
                catches.append(catchElement);
            });
        }
    }    

    function createElement(element) {
        let catchElement = $('<div>')
                    .addClass('catch')
                    .attr('data-id', element._id)
                    .append($('<label>').text('Angler'))
                    .append($('<input>')
                        .attr('type', 'text')
                        .addClass('angler')
                        .val(element.angler))
                    .append($('<label>').text('Weight'))
                    .append($('<input>')
                        .attr('type', 'number')
                        .addClass('weight')
                        .val(element.weight))
                    .append($('<label>').text('Species'))
                    .append($('<input>')
                        .attr('type', 'text')
                        .addClass('species')
                        .val(element.species))
                    .append($('<label>').text('Location'))
                    .append($('<input>')
                        .attr('type', 'text')
                        .addClass('location')
                        .val(element.location))
                    .append($('<label>').text('Bait'))
                    .append($('<input>')
                        .attr('type', 'text')
                        .addClass('bait')
                        .val(element.bait))
                    .append($('<label>').text('Capture Time'))
                    .append($('<input>')
                        .attr('type', 'text')
                        .addClass('captureTime')
                        .val(element.captureTime))
                    .append($('<button>')
                        .addClass('update')
                        .text('Update')
                        .on('click', updateCatch))
                    .append($('<button>')
                        .addClass('delete')
                        .text('Delete')
                        .on('click', deleteCatch));

        return catchElement;
    }

    function updateCatch(ev) {
        let catchId = $(ev.target).parent().attr("data-id");
        let updateUrl = `https://baas.kinvey.com/appdata/kid_ByvVKgnCQ/biggestCatches/${catchId}`;
        
        let angler = $(`.catch[data-id=${catchId}] .angler`).val();
        let weight = $(`.catch[data-id=${catchId}] .weight`).val();
        let species = $(`.catch[data-id=${catchId}] .species`).val();
        let location = $(`.catch[data-id=${catchId}] .location`).val();
        let bait = $(`.catch[data-id=${catchId}] .bait`).val();
        let captureTime = $(`.catch[data-id=${catchId}] .captureTime`).val();
        
        if(angler, weight, species, location, bait, captureTime) {
            $.ajax({
                method: 'PUT',
                url: updateUrl,
                headers: {
                    authorization: 'Basic ' + global.btoa('ruskov:123456'),
                    contentType: 'application/json'
                },
                data: JSON.stringify({                    
                    angler,
                    weight,
                    species,
                    location,
                    bait,
                    captureTime
                })
            })
            .then(function() {

            })
            .catch((err) => console.log(err));
        }
    }

    function deleteCatch(ev) {
        let target = $(ev.target).parent();
        let dataId = target.attr("data-id");
        let deleteUrl = `https://baas.kinvey.com/appdata/kid_ByvVKgnCQ/biggestCatches/${dataId}`;
        
        $.ajax({
            method: 'DELETE',
            url: deleteUrl,
            headers: {
                authorization: 'Basic ' + global.btoa('ruskov:123456'),
                contentType: 'application/json'
            }
        })
        .then(function() {
            target.remove();
        })
        .catch((err) => console.log(err));
    }
}