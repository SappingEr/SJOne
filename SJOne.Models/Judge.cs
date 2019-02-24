using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge
    {
        public virtual long Id { get; set; }

        public virtual string JudgeName { get; set; }

        public virtual string JudgeSurname { get; set; }

        public virtual IList<Athlete> Athletes { get; set; }

        public virtual IList<HandTiming> HandTimings { get; set; }

        public virtual IList<AutoTiming> AutoTimings { get; set; }
    }
}