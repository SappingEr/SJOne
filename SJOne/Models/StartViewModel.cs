﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class StartViewModel
    {
        
        public Judge Judge { get; set; }
        public IList<Judge> Judges { get; set; } = new List<Judge>();
    }
}