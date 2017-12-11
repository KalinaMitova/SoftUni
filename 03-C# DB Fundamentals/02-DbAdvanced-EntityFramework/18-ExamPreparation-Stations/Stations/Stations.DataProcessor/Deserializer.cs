
namespace Stations.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Stations.Data;
    using Stations.Models;
    using Stations.Models.enums;
    using Stations.DataProcessor.Dto.Import;
    using Stations.DataProcessor.Dto.Import.Ticket;

    using AutoMapper;

    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var stations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);

            var sb = new StringBuilder();

            var validStations = new List<Station>();

            foreach (var s in stations)
            {
                if (!IsValid(s))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (s.Town == null)
                {
                    s.Town = s.Name;
                }
                
                if (validStations.Any(vs => vs.Name == s.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = Mapper.Map<Station>(s);

                validStations.Add(station);

                sb.AppendLine(string.Format(SuccessMessage, station.Name));
            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var seatingClasses = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);

            var sb = new StringBuilder();

            var validSeatingClasses = new List<SeatingClass>();

            foreach (var sc in seatingClasses)
            {
                var isExistSeatingClasses = validSeatingClasses.Any(vsc => vsc.Name == sc.Name || vsc.Abbreviation == sc.Abbreviation);

                if (!IsValid(sc) || isExistSeatingClasses)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                var seatingClass = Mapper.Map<SeatingClass>(sc);

                validSeatingClasses.Add(seatingClass);

                sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
            }

            context.SeatingClasses.AddRange(validSeatingClasses);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var trains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();

            var validTrains = new List<Train>();

            foreach (var t in trains)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var isTrainExists = validTrains.Any(vt => vt.TrainNumber == t.TrainNumber);
                if (isTrainExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(!t.Seats.All(IsValid))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var isSeatsValid = t.Seats.All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));
                if (!isSeatsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainType = Enum.Parse<TrainType>(t.Type);
                
                var trainSeats = t.Seats.Select(s => new TrainSeat
                {
                    SeatingClass = context.SeatingClasses
                        .SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                .ToArray();

                var train = new Train()
                {
                    TrainNumber = t.TrainNumber,
                    Type = trainType,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);

                sb.AppendLine(string.Format(SuccessMessage, t.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var trips = JsonConvert.DeserializeObject<Dto.Import.TripDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();

            var validTrips = new List<Trip>();

            foreach (var t in trips)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(t.Status == null)
                {
                    t.Status = "OnTime";
                }

                var train = context.Trains
                    .SingleOrDefault(tr => tr.TrainNumber == t.Train);

                var originStation = context.Stations
                    .SingleOrDefault(s => s.Name == t.OriginStation);

                var destinationStation = context.Stations
                    .SingleOrDefault(s => s.Name == t.DestinationStation);

                if(train == null || originStation == null || destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(t.DepartureTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var arrivalTime = DateTime.ParseExact(t.ArrivalTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                if(arrivalTime < departureTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TimeSpan? timeDiff = null;
                if(t.TimeDifference != null)
                {
                    timeDiff = TimeSpan.ParseExact(t.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                var status = Enum.Parse<TripStatus>(t.Status);

                var trip = new Trip()
                {
                    Train = train,
                    OriginStation = originStation,
                    DestinationStation = destinationStation,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    TimeDifference = timeDiff,
                    Status = status
                };

                validTrips.Add(trip);

                sb.AppendLine($"Trip from {originStation.Name} to {destinationStation.Name} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(Dto.Import.CardDto[]), new XmlRootAttribute("Cards"));
            var cards = (Dto.Import.CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validCards = new List<CustomerCard>();

            foreach (var card in cards)
            {
                if (!IsValid(card))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (card.CardType == null)
                {
                    card.CardType = "Normal";
                }

                var cardType = Enum.Parse<CardType>(card.CardType);

                var customerCard = new CustomerCard()
                {
                    Name = card.Name,
                    Age = card.Age,
                    Type = cardType
                };

                validCards.Add(customerCard);

                sb.AppendLine(string.Format(SuccessMessage, customerCard.Name));
            }

            context.AddRange(validCards);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var tickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            
            var sb = new StringBuilder();

            var ValidTickets = new List<Ticket>();

            foreach (var t in tickets)
            {
                if(!IsValid(t) || !IsValid(t.Trip))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                var departureTime = DateTime.ParseExact(t.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(tr => tr.Train)
                    .ThenInclude(tr => tr.TrainSeats)
                    .Include(tr => tr.OriginStation)
                    .Include(tr => tr.DestinationStation)
                    .SingleOrDefault(tr =>
                    tr.OriginStation.Name == t.Trip.OriginStation &&
                    tr.DestinationStation.Name == t.Trip.DestinationStation &&
                    tr.DepartureTime == departureTime);

                if(trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingAbbreviation = t.Seat.Substring(0, 2);
                var seatingNumber = int.Parse(t.Seat.Substring(2));

                if(seatingNumber < 0)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClass = context.SeatingClasses
                    .SingleOrDefault(sc => sc.Abbreviation == seatingAbbreviation);

                if(seatingClass == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(!trip.Train.TrainSeats.Any(ts => 
                ts.SeatingClassId == seatingClass.Id &&
                        ts.Quantity >= seatingNumber))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (t.Card != null)
                {
                    card = context.Cards
                        .SingleOrDefault(c => c.Name == t.Card.Name);
                    
                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var ticket = new Ticket()
                {
                    Price = t.Price,
                    SeatingPlace = t.Seat,
                    Trip = trip,
                    CustomerCard = card
                };

                ValidTickets.Add(ticket);

                sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.",
                    ticket.Trip.OriginStation.Name,
                    ticket.Trip.DestinationStation.Name,
                    ticket.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Tickets.AddRange(ValidTickets);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }
        
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}