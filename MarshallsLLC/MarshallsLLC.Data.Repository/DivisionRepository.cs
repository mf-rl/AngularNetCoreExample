using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(MarshallContext context) : base(context) { }
    }
}
