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

        public virtual IList<User> Users { get; set; }          
        
        public virtual IList<Judge> Judges { get; set; }

        public virtual Event Event { get; set; }
    }
}
