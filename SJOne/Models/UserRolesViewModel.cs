using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class UserRolesViewModel
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public IList<string> UserRoles { get; set; } = new List<string>(); 
    }
}