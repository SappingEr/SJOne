using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge: User
    {
        public virtual int CountAthlete { get; set; }        

        public virtual IList<User> Users { get; set; }

        public virtual IList<HandTiming> HandTimings { get; set; }

        public virtual IList<AutoTiming> AutoTimings { get; set; }

        public virtual IList<Protocol> Protocols { get; set; }
    }
}