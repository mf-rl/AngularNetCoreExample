using MarshallsLLC.Application.Dto.Wrappers;
using System;

namespace MarshallsLLC.Application.Interfaces
{
    public interface IUriAppService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
