function calendar(inputDate) {
    
    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    let curDay = inputDate[0];
    let month = inputDate[1] - 1;
    let year = inputDate[2];
    
    let table = generateCalendar();
    let rows = generateCalendarDays();

    table.append(rows);
    $('#content').append(table);

    function generateCalendarDays() {
        let tableData = [];
        
        let currentDate = new Date(year, month, 1);
        let dayOfWeek = currentDate.getDay();
        
        if(dayOfWeek === 0) {
            dayOfWeek = 7;
        }
        dayOfWeek--;

        for (let i = 0; i < dayOfWeek; i++) {
            tableData.push($('<td>'));      
        }

        let lastDate = new Date(year, month + 1, 0);
        let totalDays = lastDate.getDate();
        for (let day = 1; day <= totalDays; day++) {
            let td = $('<td>')
                .text(day);
            
            if(curDay === day) {
                td.addClass('today');
            }
            
            tableData.push(td);
        }

        let lastDayOfWeek = lastDate.getDay();
        if(lastDayOfWeek === 0) {
            lastDayOfWeek = 7;
        }
        let length = 7 - lastDayOfWeek;
        for (let i = 0; i < length; i++) {
            tableData.push($('<td>'));            
        }

        let tableRows = [];
        for (let i = 0; i < tableData.length; i += 7) {
            let tr = $('<tr>')
                .append(tableData[i],
                    tableData[i + 1],
                    tableData[i + 2],
                    tableData[i + 3],
                    tableData[i + 4],
                    tableData[i + 5],
                    tableData[i + 6]);

            tableRows.push(tr);
        }

        return tableRows;
    }

    function generateCalendar() {
        let table = $('<table>')
            .append(
                $('<caption>')
                    .text(monthNames[month] + ' ' + year),
                $('<tbody>')
                    .append($('<tr>')
                        .append(
                            $('<th>')
                                .text("Mon"),
                            $('<th>')
                                .text("Tue"),
                            $('<th>')
                                .text("Wed"),
                            $('<th>')
                                .text("Thu"),
                            $('<th>')
                                .text("Fri"),
                            $('<th>')
                                .text("Sat"),
                            $('<th>')
                                .text("Sun"),
                            )));

        return table;        
    }
}
