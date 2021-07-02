using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(MarshallContext context) : base(context) { }
    }
}
