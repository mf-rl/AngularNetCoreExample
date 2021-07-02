using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarshallsLLC.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Office Office { get; set; }
        public Division Division { get; set; }
        public Position Position { get; set; }
        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }
        public decimal BaseSalary { get; set; }
        public ICollection<SalaryDetail> SalaryDetails { get; set; }
        public int EmployeeId { get; set; }
        public int OfficeId { get; set; }
        public int DivisionId { get; set; }
        public int PositionId { get; set; }
    }
}
