using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class EmployeeMonthlySalaryRepository : Repository<EmployeeMonthlySalary>, IEmployeeMonthlySalaryRepository
    {
        public EmployeeMonthlySalaryRepository(MarshallContext context) : base(context) { }
    }
}
