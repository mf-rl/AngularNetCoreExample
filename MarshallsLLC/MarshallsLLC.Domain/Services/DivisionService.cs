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
    public class DivisionService : Service<Division>, IDivisionService
    {
        public DivisionService(IDivisionRepository repository)
            : base(repository)
        { }
        public async Task<TransactionResult<List<Division>>> GetDivisions(Division filter)
        {
            var result = new TransactionResult<List<Division>>
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
