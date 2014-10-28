using System;
using System.Xml.Serialization;

namespace DevCraft.Scheduling
{
    public class DailySchedule : Schedule
    {
        [XmlAttribute]
        public DateTime Time { get; set; }

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