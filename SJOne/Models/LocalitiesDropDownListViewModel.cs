using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class LocalitiesDropDownListViewModel
    {
        
        [Display(Name = "Населённый пункт")]
        public long LocalityId { get; set; }
        
        public IEnumerable<SelectListItem> Localities { get; set; }
    }
}