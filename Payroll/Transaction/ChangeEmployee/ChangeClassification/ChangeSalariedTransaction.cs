using System;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.ChangeEmployee.ChangeClassification
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private double salary;

        public ChangeSalariedTransaction(int empId, double salary) : base(empId)
        {
            this.salary = salary;
        }

        public override PaymentClassification Classification
        {
            get
            {
                return new SalariedClassification(salary);
            }
        }

        public override PaymentSchedule Schedule
        {
            get
            {
                return new MonthlySchedule();
            }
        }
    }
}
