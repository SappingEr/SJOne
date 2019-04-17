using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class HandTimingViewModel
    {
        public int StartNumber { get; set; }

        public DateTime? LapTime { get; set; }

        public DateTime? TimerDelay { get; set; }

        public DateTime? TotalTime { get; set; }

        public virtual Judge Judge { get; set; }
    }
}