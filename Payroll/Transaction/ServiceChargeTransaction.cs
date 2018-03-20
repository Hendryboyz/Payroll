using Payroll.Domain;
using System;

namespace Payroll.Transaction
{
    public class ServiceChargeTransaction : Transaction
    {
        private int memberId;
        private DateTime dateTime;
        private double charge;

        public ServiceChargeTransaction(int memberId, DateTime dateTime, double charge)
        {
            this.memberId = memberId;
            this.dateTime = dateTime;
            this.charge = charge;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetUnionMember(memberId);
            if (employee == null)
            {
                throw new InvalidOperationException();
            }

            UnionAffiliation ua = employee.Affiliation as UnionAffiliation;
            if (ua != null)
            {
                ua.AddServiceCharge(new ServiceCharge(dateTime, charge));
            } 
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
