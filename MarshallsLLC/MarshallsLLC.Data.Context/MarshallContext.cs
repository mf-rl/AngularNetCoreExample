using MarshallsLLC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MarshallsLLC.Data.Context.Mapping;

namespace MarshallsLLC.Data.Context
{
    public class MarshallContext : DbContext
    {
        public MarshallContext(DbContextOptions<MarshallContext> options) : base(options) { }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<SalaryDetail> SalaryDetails { get; set; }
        public DbSet<EmployeeMonthlySalary> EmployeeMonthlySalaries { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = new EmployeeMap(modelBuilder.Entity<Employee>());
            _ = new EnrollmentMap(modelBuilder.Entity<Enrollment>());
            _ = new SalaryDetailMap(modelBuilder.Entity<SalaryDetail>());
            _ = new EmployeeMonthlySalaryMap(modelBuilder.Entity<EmployeeMonthlySalary>());
        }
    }
}
