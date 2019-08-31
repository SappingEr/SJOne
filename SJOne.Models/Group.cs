using System.Collections.Generic;

namespace SJOne.Models
{
    public class Group
    {
        public virtual long Id { get; set; }

        public virtual string GroupName { get; set; }

        public virtual string GroupDescription { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual IList<User> UsersGroup { get; set; } = new List<User>();

        public virtual IList<SubGroup> SubGroups { get; set; } = new List<SubGroup>();

    }
}
