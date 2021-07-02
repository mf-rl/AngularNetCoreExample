using MarshallsLLC.Domain.Validation;
namespace MarshallsLLC.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
