using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Application.Interfaces
{
    public interface IEnrollmentAppService : IAppService<EnrollmentDto>
    {
        Task<PagedResponse<IEnumerable<EnrollmentDto>>> Get(EnrollmentDto filter, PaginationFilter pageFilter, string route);
        Task<BaseResponseDto<EnrollmentDto>> GetCurrent(EnrollmentDto filter);
        Task<BaseResponseDto<EnrollmentDto>> Create(EnrollmentDto enrollment);
        Task<BaseResponseDto<EnrollmentDto>> Update(EnrollmentDto enrollment);
        Task<BaseResponseDto<EnrollmentDto>> Remove(int id);
    }
}
