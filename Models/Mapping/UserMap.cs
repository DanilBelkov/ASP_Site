using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_User_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_User_Id");

            builder
                .HasOne(p => p.Locality)
                .WithMany(t => t.Users)
                .HasForeignKey(t => t.LocalityId)
                .IsRequired()
                .HasConstraintName("FK_User_LId");

            builder
                .HasIndex(x => x.LocalityId)
                .HasDatabaseName("IX_User_LId");

            builder
               .HasData(new User[]
               {
                    new User { Id =  1, Name = "Иван", Surname = "Иванов", MiddleName = null, Number = "81112223344", Email = null, LocalityId = 1 }
               }) ;
        }

    }
}
