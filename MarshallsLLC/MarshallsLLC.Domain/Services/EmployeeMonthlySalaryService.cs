using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Services.Common;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Domain.Interfaces.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MarshallsLLC.Domain.Validation;
using System;

namespace MarshallsLLC.Domain.Services
{
    public class EmployeeMonthlySalaryService : Service<EmployeeMonthlySalary>, IEmployeeMonthlySalaryService
    {
        public EmployeeMonthlySalaryService(IEmployeeMonthlySalaryRepository repository)
            : base(repository) { }
        public async Task<TransactionResult<List<EmployeeMonthlySalary>>> GetEmployeeMonthlySalaries(EmployeeMonthlySalary filter)
        {
            var result = new TransactionResult<List<EmployeeMonthlySalary>>
            {
                ValidationResult = new ValidationResult()
            };
            try
            {
                result.Data = await Get(o =>
                    (filter.Id.Equals(0) || o.Id.Equals(filter.Id))
                    &&
                    (string.IsNullOrEmpty(filter.EmployeeName)
                        || (o.EmployeeName.ToLower() + " " + o.EmployeeSurname.ToLower()).Contains(filter.EmployeeName))
                    &&
                    (string.IsNullOrEmpty(filter.EmployeeSurname)
                        || (o.EmployeeName.ToLower() + " " + o.EmployeeSurname.ToLower()).Contains(filter.EmployeeSurname))
                    );
            }
            catch (Exception ex)
            {
                result.ValidationResult.Add(ex.Message);
            }
            return result;
        }
        public async Task<TransactionResult<EmployeeMonthlySalary>> AddEmployeeMonthlySalary(EmployeeMonthlySalary employeeMonthlySalary)
        {
            var result = new TransactionResult<EmployeeMonthlySalary> { ValidationResult = ValidateData(employeeMonthlySalary), Data = employeeMonthlySalary };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<EmployeeMonthlySalary> { Data = await Add(employeeMonthlySalary), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<EmployeeMonthlySalary>> UpdateEmployeeMonthlySalary(EmployeeMonthlySalary employeeMonthlySalary)
        {
            var result = new TransactionResult<EmployeeMonthlySalary> { ValidationResult = ValidateData(employeeMonthlySalary), Data = employeeMonthlySalary };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<EmployeeMonthlySalary> { Data = await Update(employeeMonthlySalary), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<EmployeeMonthlySalary>> DeleteEmployeeMonthlySalary(int id)
        {
            var employeeMonthlySalary = (await GetEmployeeMonthlySalaries(new EmployeeMonthlySalary { Id = id })).Data.FirstOrDefault();
            return new TransactionResult<EmployeeMonthlySalary> { Data = await Delete(employeeMonthlySalary), ValidationResult = null };
        }
    }
}
