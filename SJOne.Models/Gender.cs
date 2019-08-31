using System;
using System.Collections.Generic;


namespace SJOne.Models
{
    public class Gender
    {        
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<AgeGroup> AgeGroups { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
