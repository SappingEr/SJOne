using System;
using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge: User
    {
        public virtual int CountAthlete { get; set; }

        public virtual bool Ready { get; set; }

        public virtual TimeSpan? TimerDelay { get; set; }

        public virtual Race Race { get; set; }

        public virtual IList<StartNumber> StartNumbersJudge { get; set; } = new List<StartNumber>();

        public virtual IList<HandTiming> HandTimingsJudge { get; set; } = new List<HandTiming>();

        public virtual IList<AutoTiming> AutoTimingsJudge { get; set; } = new List<AutoTiming>();

        public virtual IList<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}