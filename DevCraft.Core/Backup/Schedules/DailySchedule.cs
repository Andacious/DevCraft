using System;

namespace DevCraft.Core.Backup.Schedules
{
    public class DailySchedule : ISchedule
    {
        private const Frequency _freq = Frequency.Daily;
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

        public double GetInterval(out double offset)
        {
            offset = 0;
            return 0;
        }
    }
}
