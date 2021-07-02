using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MarshallContext context) : base(context) { }
    }
}
