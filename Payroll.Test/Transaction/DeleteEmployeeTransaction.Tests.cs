using NUnit.Framework;
using Payroll.Domain;
using Payroll.Transaction;
using Payroll.Transaction.AddEmployee;

namespace Payroll.Test.Transaction
{
    [TestFixture]
    public class DeleteEmployeeTransactionTests
    {
        [Test]
        public void
            DeleteEmployee_Execute_ReturnNullFromDb()
        {
            int empId = 4;
            AddCommissionedEmployee t =
                new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);

        }
    }
}
