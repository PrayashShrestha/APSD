using System;

public class PensionPlan
{
    public required string? PlanReferenceNumber { get; set; } // Nullable, but required when PensionPlan exists
    public DateTime? EnrollmentDate { get; set; }             // Nullable for unenrolled employees
    public decimal? MonthlyContribution { get; set; }         // Nullable for unenrolled employees
}

public class Employee
{
    public long EmployeeId { get; set; }
    public required string FirstName { get; set; }            // Non-nullable, must be set
    public required string LastName { get; set; }             // Non-nullable, must be set
    public DateTime EmploymentDate { get; set; }
    public decimal YearlySalary { get; set; }
    public PensionPlan? PensionPlan { get; set; }             // Nullable, as some employees have no plan
}