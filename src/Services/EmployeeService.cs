using System;
using EmployeePensionPlan.Models;

namespace EmployeePensionPlan.Services
{
    public class EmployeeService : IEmployeeService
    {

        private static Lazy<EmployeeService> _instance;
        private List<Employee> _employees;

        private EmployeeService(List<Employee> employees)
        {
            _employees = employees ?? throw new ArgumentNullException(nameof(employees), "Employee list cannot be null");
        }

        // public method to initialize the singleton with an employee list
        public static void Initialize(List<Employee> employees)
        {
            if (_instance != null && _instance.IsValueCreated)
            {
                throw new InvalidOperationException("EmployeeService is already initialized.");
            }
            // replace the defailt Lazy instance with one that uses the provided employees
            _instance = new Lazy<EmployeeService>(() => new EmployeeService(employees), isThreadSafe: true);
        }

        // public property to acess the singleton instance
        public static IEmployeeService Instance => _instance.Value;


        // Getter for _employees
        public List<Employee> Employees => _employees;

        /* 
            Implement a feature to print-out the list of all the Employees in JSON format. The
            Company requires this list to include the Pension Plan data for each Employee (if it
            exists) and the list is to be displayed sorted in descending order of the Employees’ Yearly
            salaries and ascending order of their Last Names. 
         */
        public List<Employee> GetSortedEmployees()
        {
            return _employees
                .OrderByDescending(e => e.YearlySalary)
                .ThenBy(e => e.LastName)
                .ToList();
        }

        /*
            Implement a feature which prints out the data of the Quarterly Upcoming Enrollees report,
            in JSON format. Note: This data should contain only the list of Employees who are NOT
            enrolled for Pension and who will qualify for Pension Plan enrollment on or between the
            first and the last date of the next quarter. The Company requires this list to be displayed
            sorted in descending order of the Employees’ employment dates. 
        */
        private (DateTime startDate, DateTime endDate) GetNextQuarterDates(DateTime currentDate)
        {
            int currentQuarter = (currentDate.Month - 1) / 3 + 1;
            int nextQuarter = currentQuarter == 4 ? 1 : currentQuarter + 1;
            int nextQuarterYear = nextQuarter == 1 ? currentDate.Year + 1 : currentDate.Year;

            DateTime startDate = nextQuarter switch
            {
                1 => new DateTime(nextQuarterYear, 1, 1),
                2 => new DateTime(nextQuarterYear, 4, 1),
                3 => new DateTime(nextQuarterYear, 7, 1),
                4 => new DateTime(nextQuarterYear, 10, 1)
            };

            DateTime endDate = nextQuarter switch
            {
                1 => new DateTime(nextQuarterYear, 3, 30),
                2 => new DateTime(nextQuarterYear, 6, 30),
                3 => new DateTime(nextQuarterYear, 9, 30),
                4 => new DateTime(nextQuarterYear, 12, 30)
            };

            return (startDate, endDate);
        }

        public List<Employee> GetUpcomingEnrollees(DateTime currentDate)
        {
            var (startDate, endDate) = GetNextQuarterDates(currentDate);

            return _employees
                .Where(e => e.PensionPlan == null)
                .Where(e =>
                {
                    DateTime eligibilityDate = e.EmploymentDate.AddYears(3);
                    return eligibilityDate >= startDate && eligibilityDate <= endDate;
                })
                .OrderByDescending(e => e.EmploymentDate)
                .ToList();
        }
    }
}