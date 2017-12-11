namespace Stations.DataProcessor
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;

    using Stations.Data;
    using Stations.Models.enums;
    using Stations.DataProcessor.Dto.Export;

    using Newtonsoft.Json;

    using AutoMapper.QueryableExtensions;
    using System.Xml.Linq;

    public class Serializer
	{
		public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
		{
            var date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trains = context.Trains
                .Where(t => t.Trips
                    .Any(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date))
                .Select(t => new
                {
                    TrainNumber = t.TrainNumber,
                    Trips = t.Trips.Where(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date).ToArray()
                })
                .Select(t => new
                {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.Trips.Length,
                    MaxDelayedTime = t.Trips
                        .Max(tr => tr.TimeDifference)
                })
                .OrderByDescending(t => t.DelayedTimes)
                .ThenByDescending(t => t.MaxDelayedTime)
                .ThenBy(t => t.TrainNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(trains, Newtonsoft.Json.Formatting.Indented);

            return json;
		}

		public static string ExportCardsTicket(StationsDbContext context, string cardType)
		{
            var type = Enum.Parse<CardType>(cardType);

            var cardTypes = context.Cards
                .Where(c => c.Type == type && c.BoughtTickets.Any())
                .Select(c => new CardDto
                {
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    Tickets = c.BoughtTickets
                        .Select(bt => new TicketDto
                        {
                            OriginStation = bt.Trip.OriginStation.Name,
                            DestinationStation = bt.Trip.DestinationStation.Name,
                            DepartureTime = bt.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();
            
            var xDoc = new XDocument(new XElement("Cards"));

            foreach (var c in cardTypes)
            {
                var card = new XElement("Card", new XAttribute("name", c.Name), new XAttribute("type", c.Type.ToString()));

                var tickets = new XElement("Tickets");

                foreach (var t in c.Tickets)
                {
                    var ticket = new XElement("Ticket");

                    ticket.Add(new XElement("OriginStation", t.OriginStation));
                    ticket.Add(new XElement("DestinationStation", t.DestinationStation));
                    ticket.Add(new XElement("DepartureTime", t.DepartureTime));

                    tickets.Add(ticket);
                }

                card.Add(tickets);
                xDoc.Root.Add(card);
            }
            
            var result = xDoc.ToString();
            return result;
		}
	}
}