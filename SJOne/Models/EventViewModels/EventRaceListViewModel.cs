using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.EventViewModels
{
    public class EventRaceListViewModel
    {
        public IList<Race> Races { get; set; } = new List<Race>();
    }
}