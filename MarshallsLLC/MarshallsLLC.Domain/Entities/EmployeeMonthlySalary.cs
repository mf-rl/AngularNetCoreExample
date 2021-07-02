using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarshallsLLC.Domain.Entities
{
    public class EmployeeMonthlySalary
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string Office { get; set; }
        [Column(TypeName = "char(10)")]
        public string EmployeeCode { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Division { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Position { get; set; }
        public int Grade { get; set; }
        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Column(TypeName = "char(10)")]
        public string IdentificationNumber { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal ProductionBonus { get; set; }
        public decimal CompensationBonus { get; set; }
        public decimal Commission { get; set; }
        public decimal Contributions { get; set; }
        [NotMapped]
        public decimal OtherIncome
        {
            get
            {
                return ((BaseSalary + Commission) * (8 / 100)) + Commission;
            }
        }
        [NotMapped]
        public decimal TotalSalary
        {
            get
            {
                return BaseSalary + ProductionBonus + (CompensationBonus * (75 / 100)) + OtherIncome - Contributions;
            }
        }
    }
}
