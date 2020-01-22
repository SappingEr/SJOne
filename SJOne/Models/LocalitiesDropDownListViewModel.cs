using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class LocalitiesDropDownListViewModel
    {  
        public long LocalityId { get; set; }
        
        [Display(Name = "Населённый пункт")]        
        public IEnumerable<SelectListItem> Localities { get; set; }
    }
}