using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarshallsLLC.Domain.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "char(10)")]
        public string EmployeeCode { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Column(TypeName = "char(10)")]
        public string IdentificationNumber { get; set; }
    }
}
