using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.ChangeEmployee.ChangeClassification
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private double hourlyRate;

        public ChangeHourlyTransaction(int empId, double hourlyRate) : base(empId)
        {
            this.hourlyRate = hourlyRate;
        }

        public override PaymentClassification Classification
        {
            get
            {
                return new HourlyClassification(hourlyRate);
            }
        }

        public override PaymentSchedule Schedule
        {
            get
            {
                return new WeeklySchedule();
            }
        }
    }
}
