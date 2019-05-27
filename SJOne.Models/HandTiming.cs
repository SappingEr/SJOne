using SJOne.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class HandTiming: ITiming
    {
        public virtual long Id { get; set; } 
        
        public virtual bool Free { get; set; }

        public virtual int Lap { get; set; }
        
        public virtual TimeSpan? LapTime { get; set; }       

        public virtual TimeSpan? TotalTime { get; set; }

        public virtual DateTime? TimeStamp { get; set; }

        public virtual StartNumber StartNumber { get; set; }

        public virtual Judge Judge { get; set; }

        
    }
}
