using Newtonsoft.Json;

using EmployeePensionPlan.Models;
using EmployeePensionPlan.Services;
namespace EmployeePensionPlanApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                EmployeeID = 1,
                FirstName = "Daniel",
                LastName = "Agar",
                EmploymentDate = new DateTime(2018, 1, 17),
                YearlySalary = 105945.50m,
                PensionPlan = new PensionPlan("EX1089", new DateTime(2023, 1, 17), 100.00m)
            },
            new Employee
            {
                EmployeeID = 2,
                FirstName = "Benard",
                LastName = "Shaw",
                EmploymentDate = new DateTime(2022, 9, 3),
                YearlySalary = 197750.00m,
                PensionPlan = null
            },
            new Employee
            {
                EmployeeID = 3,
                FirstName = "Carly",
                LastName = "Agar",
                EmploymentDate = new DateTime(2014, 5, 16),
                YearlySalary = 842000.75m,
                PensionPlan = new PensionPlan("SM2307", new DateTime(2019, 11, 4), 1555.50m)
            },
            new Employee
            {
                EmployeeID = 4,
                FirstName = "Wesley",
                LastName = "Schneider",
                EmploymentDate = new DateTime(2022, 7, 21),
                YearlySalary = 74500.00m,
                PensionPlan = null
            },
            new Employee
            {
                EmployeeID = 5,
                FirstName = "Anna",
                LastName = "Wiltord",
                EmploymentDate = new DateTime(2022, 6, 15),
                YearlySalary = 85750.00m,
                PensionPlan = null
            },
            new Employee
            {
                EmployeeID = 6,
                FirstName = "Yosef",
                LastName = "Tesfalem",
                EmploymentDate = new DateTime(2022, 10, 31),
                YearlySalary = 100000.00m,
                PensionPlan = null
            }
        };

            // Initialize the singleton witht the employee list
            EmployeeService.Initialize(employees);

            // Access the singleton instance
            var employeeService = EmployeeService.Instance;

            // Feature 1: Print all employees sorted by salary (descending) and last name (ascending)
            Console.WriteLine("All Employees:");
            var allEmployees = employeeService.GetSortedEmployees();
            string allEmployeesJson = JsonConvert.SerializeObject(allEmployees, Formatting.Indented);
            Console.WriteLine(allEmployeesJson);

            // Feature 2: Quarterly Upcoming Enrollees Report
            Console.WriteLine("\nQuarterly Upcoming Enrollees:");
            DateTime currentDate = DateTime.Now; // Can replace with a fixed date for testing, e.g., new DateTime(2025, 3, 15)
            var upcomingEnrollees =
                employeeService.GetUpcomingEnrollees(currentDate);
            string upcomingEnrolleesJson = JsonConvert.SerializeObject(upcomingEnrollees, Formatting.Indented);
            Console.WriteLine(upcomingEnrolleesJson);
        }
    }
}