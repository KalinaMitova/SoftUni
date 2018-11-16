function getBugTracker() {
    let reports = {
        elements: {},
        output: ""
    };
    let currentId = 0;

    let service = Object.create(this);
    
    service.report = function(author, description, reproducible, severity) {

        let report = {
            ID: currentId,
            author,
            description,
            reproducible,
            severity,
            status: "Open"
        };

        report.element = $('<div>')
            .attr('id', `report_${report.ID}`)
            .addClass('report')
            .append($('<div>')
                .addClass('body')
                .append($('<p>')
                    .text(report.description)
                )
            )
            .append($('<div>')
                .addClass('title')
                .append($('<span>')
                    .addClass('author')
                    .text(`Submitted by: ${report.author}`)
                )
                .append($('<span>')
                    .addClass('status')
                    .text(`${report.status} | ${report.severity}`)
                )
            );

        reports.elements[currentId] = report;
        $(reports.output).append(report.element);

        currentId += 1;
    };

    service.setStatus = function(id, newStatus) {
        if(reports.elements.hasOwnProperty(id)) {
            let report = reports.elements[id];
            report.status = newStatus;
            $(`#report_${id} .status`).text(`${newStatus} | ${report.severity}`);
        }
    };

    service.remove = function(id) {
        reports.elements = Object.keys(reports.elements)
            .reduce((obj, key) => {
                if(key !== id) {
                    obj[key] = reports[key];
                }

                return obj;
            }, {});

        $(`#report_${id}`).remove();
    };

    service.sort = function(method) {
        //'author', 'severity' or 'ID'
        
        if(!method) {
            method = 'ID';
        }

        let sortedKeys;
        if(method === "author") {
            sortedKeys = Object.keys(reports.elements)
                .sort((a, b) => {
                    return reports.elements[a][method].localeCompare(reports.elements[b][method]);
                });
        } else {
            sortedKeys = Object.keys(reports.elements)
                .sort((a, b) => {
                    return reports.elements[a][method] - reports.elements[b][method];
                });
        }

        $(reports.output).html("");
        sortedKeys.forEach((key) => {
            $(reports.output).append(reports.elements[key].element);
        });
    };
    
    service.output = function (selector) {
        reports.output = selector;
    };

    return service;
}

let tracker = getBugTracker();

tracker.output('#content');
tracker.report('guy', 'report content', true, 5);
tracker.report('second guy', 'report content 2', true, 3);
tracker.report('abv', 'report content three', true, 4);

tracker.sort('author');

let report = $('#report_0');

// expect(report.find('.body p').text()).to.contains('judge rip', "Report body wasn't filled.");
// expect(report.find('.title .author').text()).to.contains('kiwi', "Report author wasn't filled.");
// expect(report.find('.title .status').text()).to.contains('Open | 5', "Report status and severity didn't match.");