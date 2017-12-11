namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Card")]
    public class CardDto
    {
        [MaxLength(128)]
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
