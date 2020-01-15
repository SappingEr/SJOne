using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SJOne.Models.UserViewModels
{
    public class LocalityViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Выберите регион.")]
        [Display(Name = "Регион")]
        public long RegionId { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }

        [Required(ErrorMessage = "Выберите населённый пункт.")]
        [Display(Name = "Населённый пункт")]
        public long LocalityId { get; set; }
        public IEnumerable<SelectListItem> Localities { get; set; }

        [Display(Name = "Спортивный клуб")]
        public bool Club { get; set; }
    }
}