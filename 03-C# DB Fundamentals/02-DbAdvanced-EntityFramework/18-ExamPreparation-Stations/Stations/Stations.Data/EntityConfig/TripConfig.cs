namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.OriginStationId)
                .IsRequired(true);

            builder.HasOne(t => t.OriginStation)
                .WithMany(s => s.TripsFrom)
                .HasForeignKey(t => t.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.DestinationStationId)
                .IsRequired(true);

            builder.HasOne(t => t.DestinationStation)
                .WithMany(s => s.TripsTo)
                .HasForeignKey(t => t.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.DepartureTime)
                .IsRequired(true);

            builder.Property(e => e.ArrivalTime)
                .IsRequired(true);

            builder.Property(e => e.TrainId)
                .IsRequired(true);

            builder.HasOne(t => t.Train)
                .WithMany(t => t.Trips)
                .HasForeignKey(t => t.TrainId);

            builder.Property(e => e.TimeDifference)
                .IsRequired(false);
        }
    }
}
