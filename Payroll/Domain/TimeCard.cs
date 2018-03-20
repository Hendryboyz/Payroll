using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public class TimeCard
    {
        private DateTime _date;
        private double _hours;

        public TimeCard(DateTime date, double workHours)
        {
            _date = date;
            _hours = workHours;
        }

        public double Hours
        {
            get
            {
                return _hours;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
        }
    }
}
