using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class LocalityMap : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Locality_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_Locality_Id");

            builder
                .HasOne(p => p.Region)
                .WithMany(t => t.Localities)
                .HasForeignKey(t => t.RegionId)
                .IsRequired()
                .HasConstraintName("FK_Locality_RId");

            builder
                .HasIndex(x => x.RegionId)
                .HasDatabaseName("IX_Locality_RId");

            builder
               .HasData(new Locality[]
               {
                    new Locality { Id =  1, Name = "Екатеринбург", RegionId = 1 }
               });

        }

    }
}
