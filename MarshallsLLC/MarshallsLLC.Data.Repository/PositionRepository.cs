using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(MarshallContext context) : base(context) { }
    }
}
