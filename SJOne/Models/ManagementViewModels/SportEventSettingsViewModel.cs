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
        
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<EventPhoto> Photos { get; set; }

        public IEnumerable<EventFile> Files { get; set; }

        public IEnumerable<Race> Races { get; set; }
    }
}