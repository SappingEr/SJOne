using System.Collections.Generic;
using System.Web.Mvc;

namespace SJOne.Models.JudgeViewModels
{
    public class LocalityDropDownListViewModel
    {        
        public IEnumerable<SelectListItem> Localities { get; set; }
    }
}