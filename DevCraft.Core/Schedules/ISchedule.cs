using DevCraft.Core.Objects;

namespace DevCraft.Core.Schedules
{
    public interface ISchedule
    {
        Frequency Freq
        {
            get;
        }

        double GetInterval(out double offset);
    }
}