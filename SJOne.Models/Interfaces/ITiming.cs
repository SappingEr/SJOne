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

        int StartNumber { get; set; }

        int Lap { get; set; }

        DateTime? LapTime { get; set; }

        DateTime? Delay { get; set; }
    }
}
