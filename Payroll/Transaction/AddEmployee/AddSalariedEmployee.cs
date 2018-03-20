using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.AddEmployee
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private double salary;

        public AddSalariedEmployee(int empId, string name, string address, double salary) 
            : base (empId, name, address)
        {
            this.salary = salary;
        }

        public override PaymentClassification CreatePaymentClassification()
        {
            return new SalariedClassification(salary);
        }

        public override PaymentSchedule CreatePaymentSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
