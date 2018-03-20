using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Transaction
{
    public class SalesReceiptTransaction : Transaction
    {
        private DateTime dateTime;
        private double amount;
        private int empId;

        public SalesReceiptTransaction(DateTime dateTime, double amount, int empId)
        {
            this.dateTime = dateTime;
            this.amount = amount;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetEmployee(empId);
            if (employee == null)
            {
                throw new InvalidOperationException();
            }

            CommissionedClassification cc = 
                employee.Classification as CommissionedClassification;
            if (cc != null)
            {
                cc.AddSalesReceipt(new SalesReceipt(dateTime, amount));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
