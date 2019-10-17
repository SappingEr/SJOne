using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class SportClubDropDownListViewModel
    {
        [Required(ErrorMessage = "Выберите клуб.")]
        [Display(Name = "Спортивный клуб")]
        public long ClubId { get; set; }
        
        public IEnumerable<SelectListItem> Clubs { get; set; }
    }
}