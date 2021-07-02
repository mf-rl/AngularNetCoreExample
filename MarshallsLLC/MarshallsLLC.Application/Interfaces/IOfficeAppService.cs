using System.Threading.Tasks;
using System.Collections.Generic;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces.Common;

namespace MarshallsLLC.Application.Interfaces
{
    public interface IOfficeAppService : IAppService<OfficeDto>
    {
        Task<BaseResponseDto<IEnumerable<OfficeDto>>> Get(OfficeDto filter);
    }
}
