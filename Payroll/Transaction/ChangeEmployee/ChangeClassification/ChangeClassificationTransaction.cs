using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.ChangeEmployee.ChangeClassification
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int empId) : base(empId)
        {
        }

        public abstract PaymentClassification Classification { get; }
        public abstract PaymentSchedule Schedule { get; }

        public override void ChangeEmployee(Employee e)
        {
            // use abstract property to implement template pattern
            e.Classification = Classification;
            e.Schedule = Schedule;
        }
    }
}
