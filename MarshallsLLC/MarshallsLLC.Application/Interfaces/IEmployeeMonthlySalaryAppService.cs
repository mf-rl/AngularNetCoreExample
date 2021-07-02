using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Application.Interfaces
{
    public interface IEmployeeMonthlySalaryAppService
    {
        Task<PagedResponse<IEnumerable<EmployeeMonthlySalaryDto>>> Get(EmployeeMonthlySalaryDto filter, PaginationFilter pageFilter, string route);
        Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Create(EmployeeMonthlySalaryDto employeeMonthlySalary);
        Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Update(EmployeeMonthlySalaryDto employeeMonthlySalary);
        Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Remove(int id);
    }
}
