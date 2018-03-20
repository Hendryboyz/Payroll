using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;

namespace Payroll.Transaction.AddEmployee
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private double _salary;
        private double _commisionRate;

        public AddCommissionedEmployee(int empId, string name, string address, double salary, double commisionRate)
            : base(empId, name, address)
        {
            _salary = salary;
            _commisionRate = commisionRate;
        }

        public override PaymentClassification CreatePaymentClassification()
        {
            return new CommissionedClassification(_salary, _commisionRate);
        }

        public override PaymentSchedule CreatePaymentSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}
