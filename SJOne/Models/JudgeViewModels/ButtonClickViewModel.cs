using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class ButtonClickViewModel
    {
        public StartNumber StartNumber { get; set; }

        public int Lap { get; set; }

        public TimeSpan? LapTime { get; set; }        

        public TimeSpan? TotalTime { get; set; }

        public virtual Judge Judge { get; set; }
    }
}