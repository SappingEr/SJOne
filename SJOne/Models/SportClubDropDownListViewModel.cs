using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class SportClubDropDownListViewModel
    {
        public long ClubId { get; set; }

        [Display(Name = "Спортивный клуб")]
        public IEnumerable<SelectListItem> Clubs { get; set; }
    }
}