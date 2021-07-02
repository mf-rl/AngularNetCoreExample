using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Services.Common;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MarshallsLLC.Domain.Validation;
using System;

namespace MarshallsLLC.Domain.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository)
            : base(repository) { }
        public async Task<TransactionResult<List<Employee>>> GetEmployees(Employee filter)
        {
            var result = new TransactionResult<List<Employee>>
            {
                ValidationResult = new ValidationResult()
            };
            try
            {
                result.Data = await Get(o =>
                    (filter.Id.Equals(0) || o.Id.Equals(filter.Id))
                    &&
                    (string.IsNullOrEmpty(filter.EmployeeName)
                        || (o.EmployeeName.ToLower() + " " + o.EmployeeSurname.ToLower()).Contains(filter.EmployeeName)
                    )
                    &&
                    (string.IsNullOrEmpty(filter.EmployeeSurname)
                        || (o.EmployeeName.ToLower() + " " + o.EmployeeSurname.ToLower()).Contains(filter.EmployeeSurname))
                    &&
                    (string.IsNullOrEmpty(filter.EmployeeCode)
                        || o.EmployeeCode.ToLower().Contains(filter.EmployeeCode))
                );
            }
            catch (Exception ex)
            {
                result.ValidationResult.Add(ex.Message);
            }
            return result;
        }
        public async Task<TransactionResult<Employee>> AddEmployee(Employee employee)
        {
            var result = new TransactionResult<Employee> { ValidationResult = ValidateData(employee), Data = employee };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<Employee> { Data = await Add(employee), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<Employee>> UpdateEmployee(Employee employee)
        {
            var result = new TransactionResult<Employee> { ValidationResult = ValidateData(employee), Data = employee };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<Employee> { Data = await Update(employee), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = (await GetEmployees(new Employee { Id = id })).Data.FirstOrDefault();
            return new TransactionResult<Employee> { Data = await Delete(employee), ValidationResult = null };
        }
    }
}
