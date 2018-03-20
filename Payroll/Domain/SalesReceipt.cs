using System;

namespace Payroll.Domain
{
    public class SalesReceipt
    {
        private DateTime dateTime;
        private double amount;

        public SalesReceipt(DateTime dateTime, double amount)
        {
            this.dateTime = dateTime;
            this.amount = amount;
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }
        }
    }
}
