using System.Collections.Generic;
using System.Web.Mvc;

namespace SJOne.Models.JudgeViewModels
{
    public class VillageDropListModel
    {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> Villages { get; set; }
    }
}