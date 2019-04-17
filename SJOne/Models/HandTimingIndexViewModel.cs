using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class HandTimingIndexViewModel
    {
        public IList<HandTiming> HandTimings { get; set; } = new List<HandTiming>();        
    }
}