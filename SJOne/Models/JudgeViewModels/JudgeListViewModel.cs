using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class JudgeListViewModel
    {
        public IEnumerable<Judge> Judges { get; set; } = new List<Judge>();
    }
}