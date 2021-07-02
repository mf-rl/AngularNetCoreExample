using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class SalaryDetailRepository : Repository<SalaryDetail>, ISalaryDetailRepository
    {
        public SalaryDetailRepository(MarshallContext context) : base(context) { }
    }
}
