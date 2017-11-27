using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DateModifier
{
    class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            var firstDateArgs = firstDate.Split();
            var firstDateYear = int.Parse(firstDateArgs[0]);
            var firstDateMonth = int.Parse(firstDateArgs[1]);
            var firstDateDay = int.Parse(firstDateArgs[2]);

            var secondDateArgs = secondDate.Split();
            var secondDateYear = int.Parse(secondDateArgs[0]);
            var secondDateMonth = int.Parse(secondDateArgs[1]);
            var secondDateDay = int.Parse(secondDateArgs[2]);

            this.FirstDate = new DateTime(firstDateYear, firstDateMonth, firstDateDay);
            this.SecondDate = new DateTime(secondDateYear, secondDateMonth, secondDateDay);
        }

        public DateTime FirstDate
        {
            get
            {
                return this.firstDate;
            }
            set
            {
                this.firstDate = value;
            }
        }

        public DateTime SecondDate
        {
            get
            {
                return this.secondDate;
            }
            set
            {
                this.secondDate = value;
            }
        }

        public int GetDaysDifference()
        {
            var daysDiff = this.firstDate - this.secondDate;
            return Math.Abs(daysDiff.Days);
        }
    }
}
