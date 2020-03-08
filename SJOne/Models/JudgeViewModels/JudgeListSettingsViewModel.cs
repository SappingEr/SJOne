using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class JudgeListSettingsViewModel
    {
        public long Id { get; set; }

        public IEnumerable<User> Judges { get; set; }

        public IEnumerable<User> JudgesRace { get; set; }
    }
}