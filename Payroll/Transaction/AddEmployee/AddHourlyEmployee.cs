using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.AddEmployee
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private double hourlyRate;

        public AddHourlyEmployee(int empId, string name, string address, double hourlyRate) 
            : base(empId, name, address)
        {
            this.hourlyRate = hourlyRate;
        }

        public override PaymentClassification CreatePaymentClassification()
        {
            return new HourlyClassification(hourlyRate);
        }

        public override PaymentSchedule CreatePaymentSchedule()
        {
            return new WeeklySchedule();
        }
    }
}
