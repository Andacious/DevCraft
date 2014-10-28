using System;
using DevCraft.Core.Objects;

namespace DevCraft.Core.Schedules
{
    public class WeeklySchedule : ISchedule
    {
        private const Frequency _freq = Frequency.Weekly;
        public Frequency Freq
        {
            get
            {
                return _freq;
            }
        }

        public DateTime Time
        {
            get;
            set;
        }

        public Day Day
        {
            get;
            set;
        }

        public double GetInterval(out double offset)
        {
            offset = 0;
            return 0;
        }
    }
}
