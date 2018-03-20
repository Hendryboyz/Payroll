using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Domain
{
    public class Employee
    {

        public Employee(int empId, string itsName, string itsAddress)
        {
            EmployeeId = empId;
            Name = itsName;
            Address = itsAddress;
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Affiliation Affiliation { get; set; }

        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
    }
}
