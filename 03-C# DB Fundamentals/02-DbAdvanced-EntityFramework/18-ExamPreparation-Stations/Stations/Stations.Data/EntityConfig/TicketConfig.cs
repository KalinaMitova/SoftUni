namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price)
                .IsRequired(true);

            builder.Property(e => e.SeatingPlace)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(e => e.TripId)
                .IsRequired(true);

            builder.HasOne(e => e.Trip)
                .WithMany(t => t.Tickets)
                .HasForeignKey(e => e.TripId);

            builder.Property(e => e.CustomerCardId)
                .IsRequired(false);

            builder.HasOne(e => e.CustomerCard)
                .WithMany(t => t.BoughtTickets)
                .HasForeignKey(e => e.CustomerCardId);
        }
    }
}
