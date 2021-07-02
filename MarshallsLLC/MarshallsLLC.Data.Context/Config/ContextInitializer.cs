using System;
using System.Linq;
using System.Collections.Generic;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Entities.Specifications;

namespace MarshallsLLC.Data.Context.Config
{
    public class ContextInitializer
    {
        public static void Initialize(MarshallContext context)
        {
            context.Database.EnsureCreated();
            List<Office> offices = new();
            List<Position> positions = new();
            List<Division> divisions = new();
            List<Employee> employees = new();
            List<Enrollment> enrollments = new();
            List<SalaryDetail> salaryDetails = new();
            if (!context.Offices.Any())
            {
                offices = new List<Office> {
                    new Office { Id = 1, Name = "A"},
                    new Office { Id = 2, Name = "B"},
                    new Office { Id = 3, Name = "C"},
                    new Office { Id = 4, Name = "ZZ"},
                };
                context.Offices.AddRange(offices);
                context.SaveChanges();
            }
            if (!context.Positions.Any())
            {
                positions = new List<Position> {
                    new Position { Id = 1, Name = "CARGO MANAGER"},
                    new Position { Id = 2, Name = "HEAD OF CARGO"},
                    new Position { Id = 3, Name = "CARGO ASSISTANT"},
                    new Position { Id = 4, Name = "SALES MANAGER"},
                    new Position { Id = 5, Name = "ACCOUNT EXECUTIVE"},
                    new Position { Id = 6, Name = "MARKETING ASSISTANT"},
                    new Position { Id = 7, Name = "CUSTOMER DIRECTOR"},
                    new Position { Id = 8, Name = "CUSTOMER ASSISTANT"},
                };
                context.Positions.AddRange(positions);
                context.SaveChanges();
            }
            if (!context.Divisions.Any())
            {
                divisions = new List<Division> {
                    new Division { Id = 1, Name = "OPERATION"},
                    new Division { Id = 2, Name = "SALES"},
                    new Division { Id = 3, Name = "MARKETING"},
                    new Division { Id = 4, Name = "CUSTOMER CARE"},
                };
                context.Divisions.AddRange(divisions);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                int[] arr = Enumerable.Range(1, 100).ToArray();
                employees = arr.Select(e => new Employee
                {
                    Id = e,
                    EmployeeCode = e.ToString().PadLeft(10, '0'),
                    EmployeeName = string.Format("Name{0}", e.ToString()),
                    EmployeeSurname = string.Format("Surname{0}", e.ToString()),
                    Birthday = RandomDay(1970, 2000),
                    IdentificationNumber = e.ToString().PadLeft(10, '0')
                }).ToList();
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
            if (!context.Enrollments.Any())
            {
                enrollments = employees.Select(e =>
                {
                    int indexTmp = RandomId(1, 5);
                    var office = offices.FirstOrDefault(o => o.Id.Equals(indexTmp));
                    indexTmp = RandomId(1, 5);
                    var division = divisions.FirstOrDefault(d => d.Id.Equals(indexTmp));
                    indexTmp = RandomId(1, 9);
                    var position = positions.FirstOrDefault(p => p.Id.Equals(indexTmp));
                    var enrollment = new Enrollment
                    {
                        Employee = e,
                        BeginDate = RandomDay(2020, 2021),
                        BaseSalary = RandomId(5, 8) * 1000,
                        Office = office,
                        Division = division,
                        Position = position,
                    };
                    return enrollment;
                }).ToList();
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }

            if (!context.SalaryDetails.Any())
            {
                salaryDetails = new List<SalaryDetail>();
                enrollments.ToList().ForEach(e =>
                {
                    foreach (var m in Enumerable.Range(1, 6).ToArray())
                    {
                        var salaryDetail = new SalaryDetail
                        {
                            Year = DateTime.Today.Year,
                            Month = m,
                            Grade = RandomId(1, 18),
                            Commission = RandomId(0, 5) * 1000,
                            CompensationBonus = RandomId(0, 5) * 1000,
                            Contributions = RandomId(0, 5) * 1000,
                            ProductionBonus = RandomId(0, 5) * 1000,
                            Enrollment = e
                        };
                        salaryDetails.Add(salaryDetail);
                    }
                });
                context.SalaryDetails.AddRange(salaryDetails);
                context.SaveChanges();

                context.EmployeeMonthlySalaries.AddRange(salaryDetails.Select(s =>
                {
                    return new SalarySpecifications().TotalSalaryCalculation(s);
                }).ToList());
                context.SaveChanges();
            }
        }
        private static DateTime RandomDay(int yearIni, int yearEnd)
        {
            Random gen = new();
            DateTime start = new(yearIni, 1, 1);
            int range = (new DateTime(yearEnd, 1, 1) - start).Days;
            return start.AddDays(gen.Next(range));
        }
        private static int RandomId(int idIni, int idEnd)
        {
            Random gen = new();
            return gen.Next(idIni, idEnd);
        }
    }
}
