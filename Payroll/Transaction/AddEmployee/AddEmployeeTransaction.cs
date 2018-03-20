using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.AddEmployee
{
    public abstract class AddEmployeeTransaction : Transaction
    {
        private int empId;
        private string itsName;
        private string itsAddress;

        protected AddEmployeeTransaction(int empId, string name, string address)
        {
            this.empId = empId;
            this.itsName = name;
            this.itsAddress = address;
        }

        public void Execute()
        {
            Employee employee = new Employee(empId, itsName, itsAddress);
            employee.Classification = CreatePaymentClassification();
            employee.Schedule = CreatePaymentSchedule();
            employee.Method = new HoldMethod();

            PayrollDatabase.AddEmployee(employee);
        }

        public abstract PaymentClassification CreatePaymentClassification();
        public abstract PaymentSchedule CreatePaymentSchedule();
    }
}
