using NUnit.Framework;
using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.Transaction;
using Payroll.Transaction.AddEmployee;
using System;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class TimecardTransactionTests
    {
        [Test]
        public void
            AddTimecard_Execute_CheckTimecardExists()
        {
            int empId = 5;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            TimeCardTransaction tct =
                new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }
    }
}
