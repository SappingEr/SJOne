using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class RaceAthletesListViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Количество участников")]
        public int AthleteCount { get; set; }

        [Display(Name = "Дистанция, м")]
        public decimal Distance { get; set; }

        [Display(Name = "Количество кругов")]
        public int LapCount { get; set; }

        [Display(Name = "Необходимое количество судей")]
        public int JudgeCount { get; set; }

        public IList<User> Athletes { get; set; } = new List<User>();
    }
}