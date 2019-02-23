using System.Collections.Generic;

namespace SJOne.Models
{
    public class Judge
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual IList<User> Users { get; set; }

        public virtual Race Race { get; set; }

    }
}