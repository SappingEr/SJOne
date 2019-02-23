using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class User: IUser<long>
    {
        public virtual long Id { get; set; }
        
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual Status Status { get; set; }        

        public virtual IList<Role> Roles { get; set; }

        public virtual Judge Judge { get; set; }
    }
}
