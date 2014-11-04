using System;

namespace DevCraft.Core.Backup.Schedules
{
    public class WeeklySchedule : ISchedule
    {
        public Frequency Freq
        {
            get
            {
                return Frequency.Weekly;
            }
        }

        public DateTime Time { get; set; }

        public Day Day { get; set; }

        public double GetInterval(out double offset)
        {
            offset = 0;
            return 0;
        }
    }
}
