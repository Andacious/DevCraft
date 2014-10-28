using System;
using System.Xml.Serialization;

namespace DevCraft.Scheduling
{
    public class WeeklySchedule : Schedule
    {
        [XmlAttribute]
        public DateTime DayTime { get; set; }

        internal override long Interval
        {
            get { throw new NotImplementedException(); }
        }

        internal override long Offset
        {
            get { throw new NotImplementedException(); }
        }
    }
}