using MarshallsLLC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarshallsLLC.Data.Context.Mapping
{
    public class SalaryDetailMap
    {
        public SalaryDetailMap(EntityTypeBuilder<SalaryDetail> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.Year).IsRequired();
            entityBuilder.Property(x => x.Month).IsRequired();
            entityBuilder.Property(x => x.Grade).IsRequired();
            entityBuilder.Property(x => x.Commission).IsRequired();
            entityBuilder.Property(x => x.Contributions).IsRequired();
            entityBuilder.Property(x => x.ProductionBonus).IsRequired();
            entityBuilder.Property(x => x.CompensationBonus).IsRequired();
        }
    }
}
