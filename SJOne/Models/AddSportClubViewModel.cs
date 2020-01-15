using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class AddSportClubViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Выберите регион.")]
        [Display(Name = "Регион")]
        public long ClubRegionId { get; set; }
        public IEnumerable<SelectListItem> ClubRegions { get; set; }

        [Required(ErrorMessage = "Выберите населённый пункт.")]
        [Display(Name = "Населённый пункт")]
        public long ClubLocalityId { get; set; }
        public IEnumerable<SelectListItem> ClubLocalities { get; set; }

        
        [Required(ErrorMessage = "Выберите клуб.")]
        [Display(Name = "Спортивный клуб")]
        public long? ClubId { get; set; }        
        public IEnumerable<SelectListItem> Clubs { get; set; }

        public string Message { get; set; }
    }
}