using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Region_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_Region_Id");

            builder
                .HasOne(p => p.Country)
                .WithMany(t => t.Regions)
                .HasForeignKey(t => t.CountryId)
                .IsRequired()
                .HasConstraintName("FK_Region_CId");

            builder
                .HasIndex(x => x.CountryId)
                .HasDatabaseName("IX_Region_CId");

            builder
               .HasData(new Region[]
               {
                    new Region { Id =  1, Name = "Свердловская область", CountryId = 1 }
               });
        }

    }
}
