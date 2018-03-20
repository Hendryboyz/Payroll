using Payroll.Domain;

namespace Payroll.Transaction.ChangeEmployee
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string address;

        public ChangeAddressTransaction(int empId, string address) : base(empId)
        {
            this.address = address;
        }

        public override void ChangeEmployee(Employee e)
        {
            e.Address = address;
        }
    }
}
