using MarshallsLLC.Domain.Validation;

namespace MarshallsLLC.Domain.Entities
{
    public class TransactionResult<TEntity>
    {
        public TEntity Data { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
