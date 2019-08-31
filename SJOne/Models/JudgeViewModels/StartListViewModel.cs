using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.JudgeViewModels
{
    public class StartListViewModel
    {
        public long Id { get; set; }        

        public int AthletesCount { get; set; }

        public int SetFirst { get; set; }

        public int SetMax { get; set; }

        public int Items { get; set; }        

        public IList<User> Athletes { get; set; } = new List<User>();       
    }
}