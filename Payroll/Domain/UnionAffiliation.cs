using System;
using System.Linq;
using System.Collections.Generic;

namespace Payroll.Domain
{
    public class UnionAffiliation : Affiliation
    {
        List<ServiceCharge> serviceCharges;

        public UnionAffiliation()
        {
            serviceCharges = new List<ServiceCharge>();
        }

        public ServiceCharge GetServiceCharge(DateTime dateTime)
        {
            return serviceCharges.Single(scs => scs.DateTime == dateTime);
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            serviceCharges.Add(serviceCharge);
        }
    }
}
