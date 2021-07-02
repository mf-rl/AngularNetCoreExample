using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace MarshallsLLC.Application.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<IEnumerable<TEntity>> CreatePagedReponse<TEntity>(
            IEnumerable<TEntity> pagedData, PaginationFilter validFilter, 
            int totalRecords, IUriAppService uriService, string route)
        {
            var respose = new PagedResponse<IEnumerable<TEntity>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
