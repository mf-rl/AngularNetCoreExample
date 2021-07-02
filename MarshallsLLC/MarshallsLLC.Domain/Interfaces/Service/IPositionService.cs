using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Domain.Interfaces.Service
{
    public interface IPositionService : IService<Position>
    {
        Task<TransactionResult<List<Position>>> GetPositions(Position filter);
    }
}
