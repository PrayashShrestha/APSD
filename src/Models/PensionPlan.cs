namespace EmployeePensionPlan.Models
{
    public class PensionPlan
    {
        public PensionPlan(string planReferenceNumber, DateTime enrollmentDate, decimal monthlyContribution)
        {
            PlanReferenceNumber = planReferenceNumber;
            EnrollmentDate = enrollmentDate;
            MonthlyContribution = monthlyContribution;
        }

        public string PlanReferenceNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal MonthlyContribution { get; set; }
    }
}