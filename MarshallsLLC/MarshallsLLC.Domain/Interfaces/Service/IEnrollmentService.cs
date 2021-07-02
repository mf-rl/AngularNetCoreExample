using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface IEnrollmentService : IService<Enrollment>
    {
        Task<TransactionResult<List<Enrollment>>> GetEnrollments(Enrollment filter);
        Task<TransactionResult<Enrollment>> AddEnrollment(Enrollment enrollment);
        Task<TransactionResult<Enrollment>> UpdateEnrollment(Enrollment enrollment);
        Task<TransactionResult<Enrollment>> DeleteEnrollment(int id);
    }
}
