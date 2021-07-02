namespace MarshallsLLC.Domain.Entities.Specifications
{
    public class SalarySpecifications
    {
        public EmployeeMonthlySalary TotalSalaryCalculation(SalaryDetail salaryDetail)
        {
            return new EmployeeMonthlySalary
            {
                //Id = salaryDetail.Id,
                Year = salaryDetail.Year,
                Month = salaryDetail.Month,
                Office = salaryDetail.Enrollment.Office.Name,
                EmployeeCode = salaryDetail.Enrollment.Employee.EmployeeCode,
                EmployeeName = salaryDetail.Enrollment.Employee.EmployeeName,
                EmployeeSurname = salaryDetail.Enrollment.Employee.EmployeeSurname,
                Division = salaryDetail.Enrollment.Division.Name,
                Position = salaryDetail.Enrollment.Position.Name,
                Grade = salaryDetail.Grade,
                BeginDate = salaryDetail.Enrollment.BeginDate,
                Birthday = salaryDetail.Enrollment.Employee.Birthday,
                IdentificationNumber = salaryDetail.Enrollment.Employee.IdentificationNumber,
                BaseSalary = salaryDetail.Enrollment.BaseSalary,
                ProductionBonus = salaryDetail.ProductionBonus,
                CompensationBonus = salaryDetail.CompensationBonus,
                Commission = salaryDetail.Commission,
                Contributions = salaryDetail.Contributions,
            };
        }
    }
}
