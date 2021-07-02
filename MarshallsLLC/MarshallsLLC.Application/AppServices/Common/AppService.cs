using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Helpers;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Application.Interfaces.Common;

namespace MarshallsLLC.Application.AppServices.Common
{
    public class AppService<TEntity> : IAppService<TEntity> where TEntity : class
    {
        private readonly IUriAppService _uriService;
        public AppService(IUriAppService uriService)
        {
            _uriService = uriService;
        }
        public PagedResponse<IEnumerable<TEntity>> PaginateData(
            IEnumerable<TEntity> listRecords, 
            PaginationFilter filter,
            string route)
        {
            int totalRecords = listRecords.Count();
            listRecords = listRecords.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).ToList();
            var pagedReponse = PaginationHelper.CreatePagedReponse(listRecords, filter, totalRecords, _uriService, route);
            return pagedReponse;
        }
    }
}
