using NUnit.Framework;
using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using Payroll.PaymentMethodStrategy;
using Payroll.PaymentScheduleStrategy;
using Payroll.Transaction.AddEmployee;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class AddEmployeeTransactionTests
    {
        [Test]
        public void
            AddEmployee_AddSalariedEmployee_CheckSalariesAndStrategy()
        {
            int empId = 1;
            AddSalariedEmployee transaction = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            transaction.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }


        [Test]
        public void
            AddEmployee_AddHourlyEmployee_CheckHourlyRateAndStrategy()
        {
            int empId = 3;
            AddHourlyEmployee transaction = 
                new AddHourlyEmployee(empId, "Bob", "Home", 19.24);
            transaction.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(19.24, sc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void
            AddEmployee_AddCommissionedEmployee_CheckSalaryAndStrategy()
        {
            int empId = 2;
            AddCommissionedEmployee transaction =
                new AddCommissionedEmployee(empId, "Bob", "Home", 1000.0, 19.24);
            transaction.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification cc = pc as CommissionedClassification;
            Assert.AreEqual(1000.0, cc.Salary, .001);
            Assert.AreEqual(19.24, cc.CommissionRate, .001);
            PaymentSchedule cs = e.Schedule;
            Assert.IsTrue(cs is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}
