namespace DevCraft.Core.Backup.Schedules
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