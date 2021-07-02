using MarshallsLLC.Domain.Interfaces.Specification;

namespace MarshallsLLC.Domain.Entities.Specifications
{
    public class EmployeeIdSpec : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Id  > 0;
        }
    }
    public class EmployeeNameSpec : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return !string.IsNullOrEmpty(employee.EmployeeName);
        }
    }
    public class EmployeeSurnameSpec : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return !string.IsNullOrEmpty(employee.EmployeeSurname);
        }
    }
    public class EmployeeIdentificationNumberSpec : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return !string.IsNullOrEmpty(employee.IdentificationNumber);
        }
    }
}
