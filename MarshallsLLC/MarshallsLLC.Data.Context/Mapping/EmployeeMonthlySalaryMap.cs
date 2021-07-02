using MarshallsLLC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarshallsLLC.Data.Context.Mapping
{
    public class EmployeeMonthlySalaryMap
    {
        public EmployeeMonthlySalaryMap(EntityTypeBuilder<EmployeeMonthlySalary> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => new { x.Year, x.Month, x.EmployeeCode }).IsUnique();
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.Year).IsRequired();
            entityBuilder.Property(x => x.Month).IsRequired();
            entityBuilder.Property(x => x.Grade).IsRequired();
            entityBuilder.Property(x => x.Birthday).IsRequired();
            entityBuilder.Property(x => x.BeginDate).IsRequired();
            entityBuilder.Property(x => x.BaseSalary).IsRequired();
            entityBuilder.Property(x => x.Commission).IsRequired();
            entityBuilder.Property(x => x.Contributions).IsRequired();
            entityBuilder.Property(x => x.ProductionBonus).IsRequired();
            entityBuilder.Property(x => x.CompensationBonus).IsRequired();
            entityBuilder.Property(x => x.Office).IsRequired().HasMaxLength(2);
            entityBuilder.Property(x => x.Division).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Position).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.EmployeeCode).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.EmployeeName).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.EmployeeSurname).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.IdentificationNumber).IsRequired().HasMaxLength(10);
        }
    }
}
