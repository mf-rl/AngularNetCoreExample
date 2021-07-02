using System.Threading.Tasks;
using System.Collections.Generic;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces.Common;

namespace MarshallsLLC.Application.Interfaces
{
    public interface ISalaryDetailAppService : IAppService<SalaryDetailDto>
    {
        Task<PagedResponse<IEnumerable<SalaryDetailDto>>> Get(SalaryDetailDto filter, PaginationFilter pageFilter, string route);
        Task<BaseResponseDto<SalaryDetailDto>> Create(SalaryDetailDto salaryDetail);
        Task<BaseResponseDto<SalaryDetailDto>> Update(SalaryDetailDto salaryDetail);
        Task<BaseResponseDto<SalaryDetailDto>> Remove(int id);
    }
}
