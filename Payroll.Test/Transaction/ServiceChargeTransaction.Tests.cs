using NUnit.Framework;
using Payroll.Domain;
using Payroll.Transaction;
using Payroll.Transaction.AddEmployee;
using System;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class ServiceChargeTransactionTests
    {
        [Test]
        public void
            ServiceChargeTransaction_AddServiceCharge_CheckChargeAmount()
        {
            int empId = 7;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;

            int memberId = 86;
            PayrollDatabase.AddUnionMember(memberId, e);

            ServiceChargeTransaction sct
                = new ServiceChargeTransaction(memberId, new DateTime(2005, 8, 8), 12.95);
            sct.Execute();

            ServiceCharge sc = af.GetServiceCharge(new DateTime(2005, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }
    }
}
