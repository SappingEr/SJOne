using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class HandTimingViewModel
    {
        public long Id { get; set; }         

        public string UserName { get; set; }

        public long StartTime { get; set; }     

        public int CountdownTime { get; set; }
    }
}