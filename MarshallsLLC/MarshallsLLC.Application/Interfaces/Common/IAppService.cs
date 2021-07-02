using MarshallsLLC.Application.Dto.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshallsLLC.Application.Interfaces.Common
{
    public interface IAppService<TEntity>
    {
        PagedResponse<IEnumerable<TEntity>> PaginateData(
            IEnumerable<TEntity> listRecords, 
            PaginationFilter filter,
            string route);
    }
}
