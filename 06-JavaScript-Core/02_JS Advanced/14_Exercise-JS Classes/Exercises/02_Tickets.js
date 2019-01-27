function getSortedTickets(ticketsInput, sortingType) {
    class Ticket{
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    ticketsInput.forEach((ticketInput) => {
        let tokens = ticketInput.split("|");
        let ticket = new Ticket(tokens[0], +tokens[1], tokens[2]);
        tickets.push(ticket);
    });

    //destination, price or status
    if(sortingType === "destination" || sortingType === "status") {
        tickets = tickets.sort((a, b) => {
            return a[sortingType].localeCompare(b[sortingType]);
        })
    }
    else if (sortingType === "price") {
        tickets = tickets.sort((a, b) => {
            return a[sortingType] - b[sortingType];
        })
    }

    return tickets;
}

let sortedTickets = getSortedTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');

console.log();