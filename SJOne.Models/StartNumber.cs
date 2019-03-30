using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class StartNumber
    {
        public virtual long Id { get; set; }

        public virtual int Number { get; set; }

        public virtual User User { get; set; }  
        
        public virtual Race Race { get; set; }
    }
}
