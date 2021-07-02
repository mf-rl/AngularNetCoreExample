using System;

namespace MarshallsLLC.Application.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
