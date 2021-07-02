using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Services.Common;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Domain.Interfaces.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using MarshallsLLC.Domain.Validation;

namespace MarshallsLLC.Domain.Services
{
    public class OfficeService : Service<Office>, IOfficeService
    {
        public OfficeService(IOfficeRepository repository)
            : base(repository)
        { }
        public async Task<TransactionResult<List<Office>>> GetOffices(Office filter)
        {
            var result = new TransactionResult<List<Office>>
            {
                ValidationResult = new ValidationResult()
            };
            try
            {
                result.Data = await Get(o =>
                    (filter.Id.Equals(0) || o.Id.Equals(filter.Id))
                );
            }
            catch (Exception ex)
            {
                result.ValidationResult.Add(ex.Message);
            }
            return result;
        }
    }
}
