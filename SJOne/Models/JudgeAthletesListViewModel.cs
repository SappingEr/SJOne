using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class JudgeAthletesListViewModel
    {
        [Display(Name = "Количество участников")]
        public int AthleteCount { get; set; }
        public IList<User> Athletes { get; set; } = new List<User>();      

    }
}