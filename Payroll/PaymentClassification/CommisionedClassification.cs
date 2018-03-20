using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Domain;

namespace Payroll.PaymentClassificationStrategy
{
    public class CommissionedClassification : PaymentClassification
    {
        private List<SalesReceipt> salesRecipts;

        public CommissionedClassification(double salary, double commisionRate)
        {
            Salary = salary;
            CommissionRate = commisionRate;
            salesRecipts = new List<SalesReceipt>();
        }

        public double Salary { get; set; }
        public double CommissionRate { get; set; }

        public SalesReceipt GetSalesReceipt(DateTime dateTime)
        {
            return salesRecipts.Single(sr => sr.DateTime == dateTime);
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            salesRecipts.Add(salesReceipt);
        }
    }
}
