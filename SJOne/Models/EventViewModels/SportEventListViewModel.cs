﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.EventViewModels
{
    public class SportEventListViewModel
    {
        public IList<SportEvent> SportEvents { get; set; } = new List<SportEvent>();
    }
}