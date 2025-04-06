using System;
using System.Data;
using EmployeePensionPlan.Models;

namespace EmployeePensionPlan.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetSortedEmployees();
        List<Employee> GetUpcomingEnrollees(DateTime currentDate);
        List<Employee> Employees { get; }
    }
}