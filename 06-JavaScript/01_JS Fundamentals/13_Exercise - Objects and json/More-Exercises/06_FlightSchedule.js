function solve(input) {
    let airport = {};

    input[0].forEach((element) => {
        let [flight, destination] = element.split(" ");

        if(!airport.hasOwnProperty(flight)) {
            airport[flight] = {
                destination,
                status: 'Ready to fly'
            };
        }
    });

    input[1].forEach((element) => {
        let [flight, status] = element.split(" ");

        if(airport.hasOwnProperty(flight)) {
            airport[flight].status = status;
        }        
    });

    let status = input[2][0];

    Object.keys(airport)
        .filter((flight) => {
            return airport[flight].status === status;
        })
        .forEach((flight) => {
            let destination = airport[flight].destination;
            let flightStatus = airport[flight].status;

            console.log(`{ Destination: '${destination}', Status: '${flightStatus}' }`);
        });
}

solve([['WN269 Delaware',
'FL2269 Oregon',
 'WN498 Las Vegas',
 'WN3145 Ohio',
 'WN612 Alabama',
 'WN4010 New York',
 'WN1173 California',
 'DL2120 Texas',
 'KL5744 Illinois',
 'WN678 Pennsylvania'],
 ['DL2120 Cancelled',
 'WN612 Cancelled',
 'WN1173 Cancelled',
 'SK330 Cancelled'],
 ['Ready to fly']
]
);