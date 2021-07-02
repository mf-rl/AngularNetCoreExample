using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface IDivisionService : IService<Division>
    {
        Task<TransactionResult<List<Division>>> GetDivisions(Division filter);
    }
}
