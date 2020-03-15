using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class AthleteTimingsViewModel
    {       
        public string JudgeName { get; set; }

        public string AthleteName { get; set; }

        public TimeSpan AverageTime { get; set; }

        public TimeSpan PredictedTime { get; set; }

        public int LapCount { get; set; } 

        public IEnumerable<HandTiming> HandTimings { get; set; }

        public IEnumerable<HandTiming> SortTimings { get; set; }

        public IEnumerable<HandTiming> ErrorTimings { get; set; }
    }
}