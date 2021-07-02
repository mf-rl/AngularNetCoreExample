namespace MarshallsLLC.Domain.Entities
{
    public class SalaryDetail
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Grade { get; set; }
        public decimal ProductionBonus { get; set; }
        public decimal CompensationBonus { get; set; }
        public decimal Commission { get; set; }
        public decimal Contributions { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
