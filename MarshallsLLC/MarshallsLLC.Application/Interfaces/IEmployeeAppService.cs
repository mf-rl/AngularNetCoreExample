using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Application.Interfaces
{
    public interface IEmployeeAppService : IAppService<EmployeeDto>
    {
        Task<PagedResponse<IEnumerable<EmployeeDto>>> Get(EmployeeDto filter, PaginationFilter pageFilter, string route);
        Task<BaseResponseDto<EmployeeDto>> Create(EmployeeDto employee);
        Task<BaseResponseDto<EmployeeDto>> Update(EmployeeDto employee);
        Task<BaseResponseDto<EmployeeDto>> Remove(int id);
    }
}
