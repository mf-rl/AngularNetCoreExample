using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Services.Common;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Domain.Interfaces.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using MarshallsLLC.Domain.Validation;

namespace MarshallsLLC.Domain.Services
{
    public class SalaryDetailService : Service<SalaryDetail>, ISalaryDetailService
    {
        private IEmployeeMonthlySalaryRepository _monthly;
        private IEnrollmentRepository _enrollment;
        private IDivisionRepository _division;
        private IOfficeRepository _office;
        private IPositionRepository _position;
        private IEmployeeRepository _employee;
        public SalaryDetailService(
            ISalaryDetailRepository repository, 
            IEmployeeMonthlySalaryRepository monthly,
            IEnrollmentRepository enrollment,
            IDivisionRepository division,
            IOfficeRepository office,
            IPositionRepository position,
            IEmployeeRepository employee)
            : base(repository)
        { 
            _monthly = monthly;
            _enrollment = enrollment;
            _division = division;
            _office = office;
            _position = position;
            _employee = employee;
        }
        public async Task<TransactionResult<List<SalaryDetail>>> GetSalaryDetails(SalaryDetail filter)
        {
            var result = new TransactionResult<List<SalaryDetail>>
            {
                ValidationResult = new ValidationResult()
            };
            try
            {
                result.Data = await Get(o =>
                    (filter.Id.Equals(0) || o.Id.Equals(filter.Id))
                );
            }
            catch (Exception ex)
            {
                result.ValidationResult.Add(ex.Message);
            }
            return result;
        }
        public async Task<TransactionResult<SalaryDetail>> AddSalaryDetail(SalaryDetail salaryDetail)
        {
            var result = new TransactionResult<SalaryDetail> { ValidationResult = ValidateData(salaryDetail), Data = salaryDetail };
            if (!result.ValidationResult.IsValid) return result;
            try
            {
                var enrollment = (await _enrollment.GetAsync(o => o.Id.Equals(salaryDetail.EnrollmentId))).FirstOrDefault();
                var employee = (await _employee.GetAsync(o => o.Id.Equals(enrollment.EmployeeId))).FirstOrDefault();
                var division = (await _division.GetAsync(o => o.Id.Equals(enrollment.DivisionId))).FirstOrDefault();
                var office = (await _office.GetAsync(o => o.Id.Equals(enrollment.OfficeId))).FirstOrDefault();
                var position = (await _position.GetAsync(o => o.Id.Equals(enrollment.PositionId))).FirstOrDefault();

                var resSalary = await Add(salaryDetail);
                //var lastId = (await _monthly.GetAsync(o => !o.Id.Equals(0))).OrderByDescending(o => o.Id).FirstOrDefault().Id;
                var resMonthly = await _monthly.AddAsync(new EmployeeMonthlySalary
                {
                    //Id = lastId + 1,
                    BaseSalary = enrollment.BaseSalary,
                    Grade = salaryDetail.Grade,
                    BeginDate = enrollment.BeginDate,
                    Commission = salaryDetail.Commission,
                    ProductionBonus = salaryDetail.ProductionBonus,
                    CompensationBonus = salaryDetail.CompensationBonus,
                    Contributions = salaryDetail.Contributions,
                    Month = salaryDetail.Month,
                    Year = salaryDetail.Year,
                    Birthday = employee.Birthday,
                    EmployeeCode = employee.EmployeeCode,
                    EmployeeName = employee.EmployeeName,
                    EmployeeSurname = employee.EmployeeSurname,
                    IdentificationNumber = employee.IdentificationNumber,
                    Division = division.Name,
                    Office = office.Name,
                    Position = position.Name
                });
                return new TransactionResult<SalaryDetail> { Data = resSalary, ValidationResult = result.ValidationResult };
            }
            catch(Exception ex)
            {
                return new TransactionResult<SalaryDetail> { 
                    Data = null, ValidationResult = new ValidationResult().Add(ex.Message).Add(ex.InnerException.Message) 
                };
            }            
        }
        public async Task<TransactionResult<SalaryDetail>> UpdateSalaryDetail(SalaryDetail salaryDetail)
        {
            var result = new TransactionResult<SalaryDetail> { ValidationResult = ValidateData(salaryDetail), Data = salaryDetail };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<SalaryDetail> { Data = await Update(salaryDetail), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<SalaryDetail>> DeleteEnrollment(int id)
        {
            var salaryDetail = (await GetSalaryDetails(new SalaryDetail { Id = id })).Data.FirstOrDefault();
            return new TransactionResult<SalaryDetail> { Data = await Delete(salaryDetail), ValidationResult = null };
        }
    }
}
