using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Group
    {
        public virtual int Id { get; set; }

        public virtual string GroupName { get; set; }

        public virtual string GroupDescription { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual IList<User> UsersGroup { get; set; } = new List<User>();

        public virtual IList<SubGroup> SubGroups { get; set; } = new List<SubGroup>();

    }
}
