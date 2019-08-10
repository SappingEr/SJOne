using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class StartListViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Количество участников")]
        public int AthletesCount { get; set; }

        public IList<User> Athletes { get; set; } = new List<User>();      

    }
}