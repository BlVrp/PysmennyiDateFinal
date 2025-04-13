using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PysmennyiDateFinal.Models.ZodiacSigns
{
    public class WesternZodiacSign(string name, DateTime startDate, DateTime endDate)
    {
        public string Name { get; } = name;
        public DateTime StartDate { get; } = startDate;
        public DateTime EndDate { get; } = endDate;

        public bool IsDateInRange(DateTime date)
        {
            return (date.Month == StartDate.Month && date.Day >= StartDate.Day) ||
                (date.Month == EndDate.Month && date.Day <= EndDate.Day);
        }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
