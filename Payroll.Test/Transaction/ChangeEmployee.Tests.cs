using NUnit.Framework;
using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentScheduleStrategy;
using Payroll.Transaction.AddEmployee;
using Payroll.Transaction.ChangeEmployee;
using Payroll.Transaction.ChangeEmployee.ChangeClassification;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class ChangeEmployeeTests
    {
        [Test]
        public void
            ChangeEmployee_ChangeName_CheckModifiedName()
        {
            int empId = 5;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeNameTransaction cnt
                = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [Test]
        public void
            ChangeEmployee_ChangeAddress_CheckModifiedAddress()
        {
            int empId = 5;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeAddressTransaction cat
                = new ChangeAddressTransaction(empId, "Company");
            cat.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Company", e.Address);
        }

        #region Change Employee Classification
        [Test]
        public void
            ChangeEmployee_ChangeClassificationToHourly_CheckPropertyType()
        {
            int empId = 5;
            AddSalariedEmployee t =
                new AddSalariedEmployee(empId, "Bill", "Home", 2000.0);
            t.Execute();

            ChangeHourlyTransaction cht
                = new ChangeHourlyTransaction(empId, 19.24);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(19.24, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsNotNull(ps);
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void
            ChangeEmployee_ChangeClassificationToSalaried_CheckPropertyType()
        {
            int empId = 5;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeSalariedTransaction cst
                = new ChangeSalariedTransaction(empId, 1000.0);
            cst.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.0, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsNotNull(ps);
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [Test]
        public void
            ChangeEmployee_ChangeClassificationToCommissioned_CheckPropertyType()
        {
            int empId = 5;
            AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeCommissionedTransaction cst
                = new ChangeCommissionedTransaction(empId, 200.0, 19.24);
            cst.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(200.0, cc.Salary, .001);
            Assert.AreEqual(19.24, cc.CommissionRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsNotNull(ps);
            Assert.IsTrue(ps is BiweeklySchedule);
        }
        #endregion



    }
}
