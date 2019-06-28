using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class FindAthleteViewModel
    {
        public long Id { get; set; }

        public string Message { get; set; } 
        
        public bool Button { get; set; }
       
        public IEnumerable<User> Athletes { get; set; }
    }
}