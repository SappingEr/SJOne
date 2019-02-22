using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Role : IRole<long>
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<User> Users { get; set; } = new List<User>();

    }
}
