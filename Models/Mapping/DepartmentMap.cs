using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MotivTest.Models.Decloration;

namespace MotivTest.Models.Mapping
{
    internal class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Department_Id");

            builder
                .HasIndex(x => x.Id)
                .HasDatabaseName("IX_Department_Id");

            builder
              .HasData(new Department[]
              {
                    new Department { Id = (int)Data.Enums.DepartmentEnum.ServiceOffice, Name = "Офис обслуживания" },
                    new Department { Id = (int)Data.Enums.DepartmentEnum.ContactCenter, Name = "Контакт-Центр" }
              });
        }

    }
}
