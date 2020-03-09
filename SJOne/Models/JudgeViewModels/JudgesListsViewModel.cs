using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class JudgesListsViewModel
    {
        public IEnumerable<User> Judges { get; set; }

        public IEnumerable<User> RaceJudges { get; set; }
    }
}