using MarshallsLLC.Data.Context;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Data.Repository.Common;
using MarshallsLLC.Domain.Interfaces.Repository;

namespace MarshallsLLC.Data.Repository
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(MarshallContext context) : base(context) { }
    }
}
