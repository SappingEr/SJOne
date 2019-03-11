using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge: User
    {
        public virtual int CountAthlete { get; set; }

        public virtual IList<User> Users { get; set; } = new List<User>();

        public virtual IList<HandTiming> HandTimings { get; set; } = new List<HandTiming>();

        public virtual IList<AutoTiming> AutoTimings { get; set; } = new List<AutoTiming>();

        public virtual IList<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}