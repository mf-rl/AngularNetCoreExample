namespace MarshallsLLC.Application.Dto
{
    public class SalaryDto
    {
        public string YearMonth { get; set; }
        public int Grade { get; set; }
        public decimal ProductionBonus { get; set; }
        public decimal CompensationBonus { get; set; }
        public decimal Commission { get; set; }
        public decimal Contributions { get; set; }
        public int EnrollmentId { get; set; }
    }
}
