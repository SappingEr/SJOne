using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class StartNumberListViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Количество участников")]
        public int NumCount { get; set; }
        public IList<StartNumber> StartNumbers { get; set; } = new List<StartNumber>();      

    }
}