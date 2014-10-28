using System;
using DevCraft.Core.Objects;

namespace DevCraft.Core.Schedules
{
    public class CustomSchedule : ISchedule
    {
        public Frequency Freq
        {
            get
            {
                return Frequency.Custom;
            }
        }
        
        public long CustomInterval { get; set; }

        public Interval CustomIntervalType { get; set; }

        public double GetInterval(out double offset)
        {
            offset = 0;

            switch (CustomIntervalType)
            {
                case Interval.Hours:
                    return TimeSpan.FromHours(CustomInterval).TotalMilliseconds;
                case Interval.Minutes:
                    return TimeSpan.FromMinutes(CustomInterval).TotalMilliseconds;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}