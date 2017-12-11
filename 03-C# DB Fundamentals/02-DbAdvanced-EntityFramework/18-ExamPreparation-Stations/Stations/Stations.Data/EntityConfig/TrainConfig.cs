namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainConfig : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TrainNumber)
                .HasMaxLength(10)
                .IsRequired(true);

            builder.HasAlternateKey(e => e.TrainNumber);

            builder.Property(e => e.Type)
                .IsRequired(false);
        }
    }
}
