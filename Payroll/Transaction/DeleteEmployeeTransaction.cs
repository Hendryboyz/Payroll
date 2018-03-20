using System;

namespace Payroll.Transaction
{
    public class DeleteEmployeeTransaction : Transaction
    {
        private int empId;

        public DeleteEmployeeTransaction(int empId)
        {
            this.empId = empId;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(empId);
        }
    }
}
