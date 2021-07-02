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
    public class PositionService : Service<Position>, IPositionService
    {
        public PositionService(IPositionRepository repository)
            : base(repository)
        { }
        public async Task<TransactionResult<List<Position>>> GetPositions(Position filter)
        {
            var result = new TransactionResult<List<Position>>
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
