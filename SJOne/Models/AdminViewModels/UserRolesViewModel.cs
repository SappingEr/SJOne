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

        public string Data { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
    }
}