using System;
using System.Collections.Generic;

namespace MarshallsLLC.Application.Dto
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public EmployeeDto Employee { get; set; }
        public OfficeDto Office { get; set; }
        public DivisionDto Division { get; set; }
        public PositionDto Position { get; set; }
        public DateTime BeginDate { get; set; }
        public decimal BaseSalary { get; set; }
        public ICollection<SalaryDetailDto> SalaryDetails { get; set; }
    }
}
