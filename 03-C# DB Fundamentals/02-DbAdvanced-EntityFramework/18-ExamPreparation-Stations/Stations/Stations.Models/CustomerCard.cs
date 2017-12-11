namespace Stations.Models
{
    using System.Collections.Generic;

    using Stations.Models.enums;
    using System.ComponentModel.DataAnnotations;

    public class CustomerCard
    {
        public CustomerCard()
        {
            this.Type = CardType.Normal;
            this.BoughtTickets = new List<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public CardType Type { get; set; } = CardType.Normal;

        public ICollection<Ticket> BoughtTickets { get; set; }
    }

    
}
