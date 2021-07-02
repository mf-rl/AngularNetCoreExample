using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface IEmployeeMonthlySalaryService : IService<EmployeeMonthlySalary>
    {
        Task<TransactionResult<List<EmployeeMonthlySalary>>> GetEmployeeMonthlySalaries(EmployeeMonthlySalary filter);
        Task<TransactionResult<EmployeeMonthlySalary>> AddEmployeeMonthlySalary(EmployeeMonthlySalary employeeMonthlySalary);
        Task<TransactionResult<EmployeeMonthlySalary>> UpdateEmployeeMonthlySalary(EmployeeMonthlySalary employeeMonthlySalary);
        Task<TransactionResult<EmployeeMonthlySalary>> DeleteEmployeeMonthlySalary(int id);
    }
}