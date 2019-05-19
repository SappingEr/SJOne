using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class SportEventSettingsViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]        
        public string EventName { get; set; }

        [Display(Name = "Описание")]       
        public string Description { get; set; }

        [Display(Name = "Дата")]        
        public DateTime EventDate { get; set; }
    }
}