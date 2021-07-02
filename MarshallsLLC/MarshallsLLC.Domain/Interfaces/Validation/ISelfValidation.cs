using MarshallsLLC.Domain.Validation;
namespace MarshallsLLC.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
