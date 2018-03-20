using NUnit.Framework;
using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.Transaction;
using Payroll.Transaction.AddEmployee;
using System;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class SaleReceiptTransaction
    {
        [Test]
        public void
            AddSaleReceipt_Execute_CheckAmount()
        {
            int empId = 6;
            AddCommissionedEmployee t =
                new AddCommissionedEmployee(empId, "Bill", "Home", 200.0, 15.25);
            t.Execute();

            SalesReceiptTransaction srt =
                new SalesReceiptTransaction(new DateTime(2005, 7, 31), 8.0, empId);
            srt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            SalesReceipt sr = cc.GetSalesReceipt(new DateTime(2005, 7, 31));
            Assert.IsNotNull(sr);
            Assert.AreEqual(8.0, sr.Amount);
        }
    }
}
