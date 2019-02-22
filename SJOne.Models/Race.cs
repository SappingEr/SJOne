using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Race
    {
        public virtual long Id { get; set; }

        public virtual IList<Athlete> Athletes { get; set; }

        public virtual int LapCount { get; set; }

        public virtual DateTime LapTime { get; set; }

        public virtual DateTime TotalTime { get; set; }

        public virtual IList<Judge> Judges { get; set; }
    }
}
