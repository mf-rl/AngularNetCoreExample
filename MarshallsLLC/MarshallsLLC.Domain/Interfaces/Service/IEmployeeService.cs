using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<TransactionResult<List<Employee>>> GetEmployees(Employee filter);
        Task<TransactionResult<Employee>> UpdateEmployee(Employee employee);
        Task<TransactionResult<Employee>> DeleteEmployee(int id);
        Task<TransactionResult<Employee>> AddEmployee(Employee employee);
    }
}