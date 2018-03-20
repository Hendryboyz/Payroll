using Payroll.Domain;
using Payroll.PaymentClassificationStrategy;
using System;

namespace Payroll.Transaction
{
    public class TimeCardTransaction : Transaction
    {
        private DateTime _dateTime;
        private double _workTime;
        private int _empId;

        public TimeCardTransaction(DateTime dateTime, double workTime, int empId)
        {
            _dateTime = dateTime;
            _workTime = workTime;
            _empId = empId;
        }

        public void Execute()
        {
            Employee employee = PayrollDatabase.GetEmployee(_empId);
            if (employee == null)
            {
                throw new InvalidOperationException("No such employee");
            }
            HourlyClassification hc = employee.Classification as HourlyClassification;
            if (hc != null)
            {
                TimeCard tc = new TimeCard(_dateTime, _workTime);
                hc.AddTimeCard(tc);
            }
            else
            {
                throw new InvalidOperationException ("Tried to add timecard to non-hourly employee");
            }
        }
    }
}
