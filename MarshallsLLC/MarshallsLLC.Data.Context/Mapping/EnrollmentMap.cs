using MarshallsLLC.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarshallsLLC.Data.Context.Mapping
{
    public class EnrollmentMap
    {
        public EnrollmentMap(EntityTypeBuilder<Enrollment> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.BeginDate).IsRequired();
            entityBuilder.Property(x => x.BaseSalary).IsRequired();
        }
    }
}
