using System;

namespace TemporarySecretary
{
    public class DateSpan
    {
        public DateSpan(DateTime start, DateTime stop)
        {
            Start = start;
            Stop = stop;
        }

        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public bool Overlapped(DateSpan span)
        {
            if (span.Stop <= Stop && span.Stop >= Start)
                return true;
            if (span.Start <= Stop && span.Start >= Start)
                return true;
            if (span.Start <= Start && span.Stop >= Stop)
                return true;

            return false;
        }
    }
}
