using System;

namespace DevCraft.Core.Backup.Schedules
{
    public class DailySchedule : ISchedule
    {
        public Frequency Freq
        {
            get
            {
                return Frequency.Daily;
            }
        }

        public DateTime Time { get; set; }

        public double GetInterval(out double offset)
        {
            offset = 0;
            return 0;
        }
    }
}
