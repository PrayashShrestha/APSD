using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee 
            { 
                EmployeeId = 1, 
                FirstName = "Daniel", 
                LastName = "Agar", 
                EmploymentDate = new DateTime(2018, 1, 17), 
                YearlySalary = 105945.50m, 
                PensionPlan = new PensionPlan 
                { 
                    PlanReferenceNumber = "EX1089", 
                    EnrollmentDate = new DateTime(2023, 1, 17), 
                    MonthlyContribution = 100.00m 
                } 
            },
            new Employee 
            { 
                EmployeeId = 2, 
                FirstName = "Benard", 
                LastName = "Shaw", 
                EmploymentDate = new DateTime(2022, 9, 3), 
                YearlySalary = 197750.00m, 
                PensionPlan = null 
            },
            new Employee 
            { 
                EmployeeId = 3, 
                FirstName = "Carly", 
                LastName = "Agar", 
                EmploymentDate = new DateTime(2014, 5, 16), 
                YearlySalary = 842000.75m, 
                PensionPlan = new PensionPlan 
                { 
                    PlanReferenceNumber = "SM2307", 
                    EnrollmentDate = new DateTime(2019, 11, 4), 
                    MonthlyContribution = 1555.50m 
                } 
            },
            new Employee 
            { 
                EmployeeId = 4, 
                FirstName = "Wesley", 
                LastName = "Schneider", 
                EmploymentDate = new DateTime(2022, 7, 21), 
                YearlySalary = 74500.00m, 
                PensionPlan = null 
            },
            new Employee 
            { 
                EmployeeId = 5, 
                FirstName = "Anna", 
                LastName = "Wiltord", 
                EmploymentDate = new DateTime(2022, 6, 15), 
                YearlySalary = 85750.00m, 
                PensionPlan = null 
            },
            new Employee 
            { 
                EmployeeId = 6, 
                FirstName = "Yosef", 
                LastName = "Tesfalem", 
                EmploymentDate = new DateTime(2022, 10, 31), 
                YearlySalary = 100000.00m, 
                PensionPlan = null 
            }
        };

        // Feature 1: Print all employees sorted by salary (descending) and last name (ascending)
        Console.WriteLine("All Employees:");
        var sortedEmployees = employees
            .OrderByDescending(e => e.YearlySalary)
            .ThenBy(e => e.LastName)
            .ToList();
        string employeesJson = JsonConvert.SerializeObject(sortedEmployees, Formatting.Indented);
        Console.WriteLine(employeesJson);

        // Feature 2: Quarterly Upcoming Enrollees Report
        Console.WriteLine("\nQuarterly Upcoming Enrollees:");
        DateTime currentDate = DateTime.Now; // Can replace with a fixed date for testing, e.g., new DateTime(2025, 3, 15)
        var (nextQuarterStart, nextQuarterEnd) = GetNextQuarterDates(currentDate);
        var upcomingEnrollees = employees
            .Where(e => e.PensionPlan == null &&
                        e.EmploymentDate.AddYears(3) >= nextQuarterStart &&
                        e.EmploymentDate.AddYears(3) <= nextQuarterEnd)
            .OrderByDescending(e => e.EmploymentDate)
            .ToList();
        string upcomingJson = JsonConvert.SerializeObject(upcomingEnrollees, Formatting.Indented);
        Console.WriteLine(upcomingJson);
    }

    // Helper method to calculate the next quarter's date range
    static (DateTime nextQuarterStart, DateTime nextQuarterEnd) GetNextQuarterDates(DateTime currentDate)
    {
        int currentQuarter = (currentDate.Month - 1) / 3 + 1;
        int nextQuarter = currentQuarter == 4 ? 1 : currentQuarter + 1;
        int year = currentQuarter == 4 ? currentDate.Year + 1 : currentDate.Year;

        DateTime nextQuarterStart = nextQuarter switch
        {
            1 => new DateTime(year, 1, 1),
            2 => new DateTime(year, 4, 1),
            3 => new DateTime(year, 7, 1),
            4 => new DateTime(year, 10, 1),
            _ => throw new Exception("Invalid quarter")
        };
        DateTime nextQuarterEnd = nextQuarterStart.AddMonths(3).AddDays(-1);
        return (nextQuarterStart, nextQuarterEnd);
    }
}