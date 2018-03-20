using System;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.ChangeEmployee.ChangeClassification
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private double salary;
        private double commissionRate;

        public ChangeCommissionedTransaction(int empId, double salary, double commissionRate) : base(empId)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        public override PaymentClassification Classification
        {
            get
            {
                return new CommissionedClassification(salary, commissionRate);
            }
        }

        public override PaymentSchedule Schedule
        {
            get
            {
                return new BiweeklySchedule();
            }
        }
    }
}
