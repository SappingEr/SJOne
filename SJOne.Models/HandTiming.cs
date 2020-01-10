using SJOne.Models.Interfaces;
using System;

namespace SJOne.Models
{
    public class HandTiming : ITiming
    {
        public virtual long Id { get; set; }

        public virtual int Lap { get; set; }

        public virtual TimeSpan? LapTime { get; set; }

        public virtual TimeSpan? TotalTime { get; set; }

        public virtual DateTime? TimeStamp { get; set; }

        public virtual StartNumber StartNumber { get; set; }

        public virtual User Judge { get; set; }


    }
}
