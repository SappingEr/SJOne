using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class RaceResultsViewModel
    {
        public long Id { get; set; }

        public IEnumerable<User> Athletes { get; set; }
    }
}