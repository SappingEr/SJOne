using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class SelectRolesViewModel
    {
        public long Id { get; set; }

        public string[] RoleName { get; set; }

        public MultiSelectList RoleList { get; set; }

    }
}