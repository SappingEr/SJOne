﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class UserViewModel
    {
        public IList<User> Users { get; set; } = new List<User>();
    }
}