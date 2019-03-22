using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class RaceAthleteListViewModel
    {
        public int AthleteCount { get; set; }

        public double Distance { get; set; }

        public int LapCount { get; set; }

        public int JudgeCount { get; set; }

        public IList<User> Athletes { get; set; } = new List<User>();
    }
}