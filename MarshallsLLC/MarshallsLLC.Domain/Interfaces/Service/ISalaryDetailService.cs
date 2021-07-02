using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface ISalaryDetailService : IService<SalaryDetail>
    {
        Task<TransactionResult<List<SalaryDetail>>> GetSalaryDetails(SalaryDetail filter);
        Task<TransactionResult<SalaryDetail>> AddSalaryDetail(SalaryDetail salaryDetail);
        Task<TransactionResult<SalaryDetail>> UpdateSalaryDetail(SalaryDetail salaryDetail);
        Task<TransactionResult<SalaryDetail>> DeleteEnrollment(int id);
    }
}
