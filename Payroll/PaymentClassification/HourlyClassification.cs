using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Domain;

namespace Payroll.PaymentClassificationStrategy
{
    public class HourlyClassification : PaymentClassification
    {
        List<TimeCard> timeCards;

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
            timeCards = new List<TimeCard>();
        }

        public double HourlyRate { get; set; }

        public TimeCard GetTimeCard(DateTime dateTime)
        {
            return timeCards.SingleOrDefault( tc => tc.Date == dateTime);
        }

        public void AddTimeCard(TimeCard tc)
        {
            timeCards.Add(tc);
        }
    }
}
