//using System;

//namespace DevCraft
//{
//    public class Schedule
//    {
//        /// <summary>
//        /// The type of frequency.
//        /// </summary>
//        public Frequency Frequency 
//        { 
//            get; 
//            set; 
//        }

//        /// <summary>
//        /// The day to backup.
//        /// </summary>
//        public Day Day 
//        { 
//            get; 
//            set; 
//        }

//        private DateTime _time = DateTime.Now;

//        /// <summary>
//        /// The time to backup.
//        /// </summary>
//        public DateTime Time 
//        {
//            get
//            {
//                return _time;
//            }
//            set
//            {
//                _time = value;
//            }
//        }

//        /// <summary>
//        /// The custom interval data.
//        /// </summary>
//        public long CustomInterval 
//        { 
//            get; 
//            set; 
//        }

//        /// <summary>
//        /// What to interpret the custom interval data as.
//        /// </summary>
//        public Interval CustomIntervalType 
//        { 
//            get; 
//            set; 
//        }

//        private bool _displayStatus = true;

//        /// <summary>
//        /// Display backup notifications to in-game users.
//        /// </summary>
//        public bool DisplayStatus 
//        {
//            get
//            {
//                return _displayStatus;
//            }
//            set
//            {
//                _displayStatus = value;
//            }
//        }
//    }
//}
