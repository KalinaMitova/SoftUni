namespace Stations.Models
{
    using System;
    using System.Collections.Generic;

    using Stations.Models.enums;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        public Trip()
        {
            this.Status = TripStatus.OnTime;
        }

        public int Id { get; set; }

        public int OriginStationId { get; set; }

        [Required]
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }

        [Required]
        public Station DestinationStation { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public int TrainId { get; set; }

        [Required]
        public Train Train { get; set; }

        public TripStatus Status { get; set; } = TripStatus.OnTime;

        public TimeSpan? TimeDifference { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }    
}
