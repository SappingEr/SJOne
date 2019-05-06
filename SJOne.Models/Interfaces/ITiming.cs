using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Interfaces
{
    interface ITiming
    {
        long Id { get; set; }

        StartNumber StartNumber { get; set; }

        int Lap { get; set; }

        TimeSpan? LapTime { get; set; }

        TimeSpan? TotalTime { get; set; }

        DateTime? TimeStamp { get; set; }
        
    }
}
