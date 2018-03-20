using Payroll.Domain;
using System;

namespace Payroll.Transaction.ChangeEmployee
{
    public abstract class ChangeEmployeeTransaction : Transaction
    {
        protected int empId;

        public ChangeEmployeeTransaction(int empId)
        {
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e == null)
            {
                throw new InvalidOperationException();
            }

            ChangeEmployee(e);
        }

        public abstract void ChangeEmployee(Employee e);
    }
}
