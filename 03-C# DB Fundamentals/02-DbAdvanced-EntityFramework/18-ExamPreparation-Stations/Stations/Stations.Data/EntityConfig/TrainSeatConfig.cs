namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainSeatConfig : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TrainId)
                .IsRequired(true);

            builder.Property(e => e.SeatingClassId)
                .IsRequired(true);

            builder.HasOne(ts => ts.Train)
                .WithMany(t => t.TrainSeats)
                .HasForeignKey(ts => ts.TrainId);

            builder.HasOne(ts => ts.SeatingClass)
                .WithMany(sc => sc.TrainSeats)
                .HasForeignKey(ts => ts.SeatingClassId);

            builder.Property(e => e.Quantity)
                .IsRequired(true);
        }
    }
}
