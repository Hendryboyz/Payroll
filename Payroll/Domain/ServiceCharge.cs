using System;

namespace Payroll.Domain
{
    public class ServiceCharge
    {
        private DateTime dateTime;
        private double amount;

        public ServiceCharge(DateTime dateTime, double amount)
        {
            this.dateTime = dateTime;
            this.amount = amount;
        }

        public double Amount
        {
            get
            {
                return amount;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
        }
    }
}
