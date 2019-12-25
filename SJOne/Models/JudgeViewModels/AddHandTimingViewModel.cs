using System;

namespace SJOne.Models
{
    public class AddHandTimingViewModel
    {
        public StartNumber StartNumber { get; set; }

        public int Lap { get; set; }

        public TimeSpan LapTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public DateTime TimeStamp { get; set; }        
    }
}