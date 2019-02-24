using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Event
    {
        public virtual long Id { get; set; }

        public virtual string EventName { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime EventDate { get; set; }

        public virtual IList<EventFile> EventFiles { get; set; }

        public virtual IList<Race> Races { get; set; }
    }
}
