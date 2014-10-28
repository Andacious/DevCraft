using System.Xml.Serialization;

namespace DevCraft.Scheduling
{
    public class CustomSchedule : Schedule
    {
        [XmlAttribute]
        public long CustomInterval { get; set; }

        internal override long Interval
        {
            get 
            {
                return CustomInterval;
            }
        }
    }
}