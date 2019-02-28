using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class HandTiming
    {
        public virtual long Id { get; set; }

        public virtual int StartNumber  { get; set; }

        public virtual int Lap { get; set; }
        
        public virtual DateTime LapTime { get; set; }  
        
        public virtual Judge Judge { get; set; } 
    }
}
