using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Request_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_Request_Id");

            builder
                .HasOne(p => p.User)
                .WithMany(t => t.Requests)
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .HasConstraintName("FK_Request_UId");

            builder
                .HasIndex(x => x.UserId)
                .HasDatabaseName("IX_Request_UId");

            builder
               .HasOne(p => p.Department)
               .WithMany(t => t.Requests)
               .HasForeignKey(t => t.DepartmentId)
               .IsRequired()
               .HasConstraintName("FK_Request_DId");

            builder
                .HasIndex(x => x.DepartmentId)
                .HasDatabaseName("IX_Request_DId");

            builder
              .HasData(new Request[]
              {
                    new Request { Id =  1, Name = "Обращение 1", DepartmentId = (int)Data.Enums.DepartmentEnum.ContactCenter, Date = DateTime.Now, Reason = "Замена номера", UserId = 1}
              });
        }

    }
}
