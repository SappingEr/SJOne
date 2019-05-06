using SJOne.Models.Interfaces;
using System;

namespace SJOne.Models
{
    public class AutoTiming : ITiming
    {
        public virtual long Id { get; set; }        

        public virtual int Lap { get; set; }

        public virtual TimeSpan? LapTime { get; set; }

        public virtual TimeSpan? TotalTime { get; set; }

        public virtual StartNumber StartNumber { get; set; }

        public virtual Judge Judge { get; set; }

        public virtual DateTime? TimeStamp { get; set; }
    }
}