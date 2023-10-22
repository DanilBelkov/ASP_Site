using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Country_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_Country_Id");

            builder
                .HasData(new Country[]
                {
                    new Country { Id =  1, Name = "Россия", ShortName = "RUS" },
                    new Country { Id =  2, Name = "Казахстан", ShortName = "KZ" }
                });
        }

    }
}
