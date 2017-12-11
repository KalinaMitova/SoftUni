namespace Stations.Data.EntityConfig
{
    using Stations.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SeatingClassConfig : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.HasAlternateKey(e => e.Name);

            builder.Property(e => e.Abbreviation)
                .HasColumnType("CHAR(2)")
                .IsRequired(true);

            builder.HasAlternateKey(e => e.Abbreviation);
        }
    }
}
