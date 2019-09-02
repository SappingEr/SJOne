using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Models.JudgeViewModels
{
    public class StartListSettingsViewModel
    {
        public long Id { get; set; }        
        
        public Gender Gender { get; set; }

        public long AgeGroupId { get; set; }

        public IEnumerable<SelectListItem> AgeGroups { get; set; }

        public long JudgeId { get; set; }
        
        public IEnumerable<SelectListItem> Judges { get; set; }
    }
}