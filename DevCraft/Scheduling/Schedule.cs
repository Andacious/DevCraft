using System.Xml.Serialization;

namespace DevCraft.Scheduling
{
    public abstract class Schedule
    {
        [XmlAttribute]
        public bool DisplayBackupStatus { get; set; }

        internal abstract long Interval { get; }

        internal virtual long Offset 
        {
            get
            {
                // default to no offset calculation unless otherwise specified
                return 0;
            }
        }
    }
}