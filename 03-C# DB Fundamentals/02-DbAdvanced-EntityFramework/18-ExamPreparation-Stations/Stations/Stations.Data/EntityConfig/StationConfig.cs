namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StationConfig : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasAlternateKey(e => e.Name);

            builder.Property(e => e.Town)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}
