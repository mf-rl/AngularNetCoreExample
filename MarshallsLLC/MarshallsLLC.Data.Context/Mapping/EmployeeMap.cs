using MarshallsLLC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MarshallsLLC.Data.Context.Mapping
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.EmployeeCode).IsUnique();
            entityBuilder.HasIndex(x => new { x.EmployeeName, x.EmployeeSurname }).IsUnique();
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.Birthday).IsRequired();
            entityBuilder.Property(x => x.EmployeeCode).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.EmployeeName).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.EmployeeSurname).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.IdentificationNumber).IsRequired().HasMaxLength(10);
        }
    }
}
