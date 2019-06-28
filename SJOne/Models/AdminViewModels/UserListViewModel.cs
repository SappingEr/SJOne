using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.AdminViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}