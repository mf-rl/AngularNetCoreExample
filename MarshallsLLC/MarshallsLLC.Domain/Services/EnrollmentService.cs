using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Validation;
using MarshallsLLC.Domain.Services.Common;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Domain.Services
{
    public class EnrollmentService : Service<Enrollment>, IEnrollmentService
    {
        public EnrollmentService(IEnrollmentRepository repository)
            : base(repository){ }
        public async Task<TransactionResult<List<Enrollment>>> GetEnrollments(Enrollment filter)
        {
            var result = new TransactionResult<List<Enrollment>>
            {
                ValidationResult = new ValidationResult()
            };
            try
            {
                result.Data = await Get(o =>
                    (filter.Id.Equals(0) || o.Id.Equals(filter.Id))
                    &&
                    (filter.Employee.Id.Equals(0) || o.Employee.Id.Equals(filter.Employee.Id))
                );
            }
            catch(Exception ex)
            {
                result.ValidationResult.Add(ex.Message);
            }
            return result;            
        }
        public async Task<TransactionResult<Enrollment>> AddEnrollment(Enrollment enrollment)
        {
            var result = new TransactionResult<Enrollment> { ValidationResult = ValidateData(enrollment), Data = enrollment };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<Enrollment> { Data = await Add(enrollment), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<Enrollment>> UpdateEnrollment(Enrollment enrollment)
        {
            var result = new TransactionResult<Enrollment> { ValidationResult = ValidateData(enrollment), Data = enrollment };
            if (!result.ValidationResult.IsValid) return result;
            return new TransactionResult<Enrollment> { Data = await Update(enrollment), ValidationResult = result.ValidationResult };
        }
        public async Task<TransactionResult<Enrollment>> DeleteEnrollment(int id)
        {
            var employee = (await GetEnrollments(new Enrollment { Id = id })).Data.FirstOrDefault();
            return new TransactionResult<Enrollment> { Data = await Delete(employee), ValidationResult = null };
        }
    }
}
