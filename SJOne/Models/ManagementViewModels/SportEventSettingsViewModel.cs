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
           
        public string EventName { get; set; }
          
        public string Description { get; set; }
                
        public DateTime EventDate { get; set; }
    }
}