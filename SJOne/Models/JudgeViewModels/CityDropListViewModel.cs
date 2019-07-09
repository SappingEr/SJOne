using System.Collections.Generic;
using System.Web.Mvc;

namespace SJOne.Models.JudgeViewModels
{
    public class CityDropListViewModel
    {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}