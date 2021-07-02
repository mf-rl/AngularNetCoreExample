using MarshallsLLC.Domain.Entities.Specifications;
using MarshallsLLC.Domain.Validation;

namespace MarshallsLLC.Domain.Entities.Validations
{
    public class EmployeeValidation : Validation<Employee>
    {
        public EmployeeValidation()
        {
            base.AddRule(new ValidationRule<Employee>(new EmployeeIdSpec(), ValidationMessages.EmployeeIdError));
            base.AddRule(new ValidationRule<Employee>(new EmployeeNameSpec(), ValidationMessages.EmployeeNameError));
            base.AddRule(new ValidationRule<Employee>(new EmployeeSurnameSpec(), ValidationMessages.EmployeeSurnameError));
            base.AddRule(new ValidationRule<Employee>(new EmployeeIdentificationNumberSpec(), ValidationMessages.EmployeeIdentificationNumberError));
        }
    }
}
