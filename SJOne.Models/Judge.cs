using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge: User
    {
        public virtual int CountAthlete { get; set; }

        public virtual bool Ready { get; set; }
        
        public virtual Race Race { get; set; }

        public override IList<StartNumber> StartNumbers { get; set; } = new List<StartNumber>();

        public virtual IList<HandTiming> HandTimings { get; set; } = new List<HandTiming>();

        public virtual IList<AutoTiming> AutoTimings { get; set; } = new List<AutoTiming>();

        public virtual IList<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}