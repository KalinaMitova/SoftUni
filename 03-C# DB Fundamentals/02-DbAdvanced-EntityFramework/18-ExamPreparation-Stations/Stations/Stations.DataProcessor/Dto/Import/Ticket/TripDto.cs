namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Trip")]
    public class TripDto
    {
        [Required]
        [MaxLength(50)]
        [XmlElement("OriginStation")]
        public string OriginStation { get; set; }

        [Required]
        [MaxLength(50)]
        [XmlElement("DestinationStation")]
        public string DestinationStation { get; set; }

        [Required]
        [XmlElement("DepartureTime")]
        public string DepartureTime { get; set; }
    }
}
