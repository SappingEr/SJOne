using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class JudgeListViewModel
    {
        public long Id { get; set; }
        public IList<User> Judges { get; set; } = new List<User>();
    }
}