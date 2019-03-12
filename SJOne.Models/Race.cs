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
        
        public virtual double Distance { get; set; }       

        public virtual int LapCount { get; set; }

        public virtual IList<User> Users { get; set; } = new List<User>();

        public virtual IList<Judge> Judges { get; set; } = new List<Judge>();

        public virtual IList<StartNumber> StartNumbers { get; set; } = new List<StartNumber>();

        public virtual Event Event { get; set; }
    }
}
