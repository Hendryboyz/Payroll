using Payroll.Domain;

namespace Payroll.Transaction.ChangeEmployee
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private string name;

        public ChangeNameTransaction(int empId, string name) : base(empId)
        {
            this.name = name;
        }

        public override void ChangeEmployee(Employee e)
        {
            e.Name = name;
        }
    }
}
