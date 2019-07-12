

using System.Collections.Generic;

namespace SJOne.Models
{
    public class Locality
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        
        public virtual Region Region { get; set; }

        public virtual IList<User> LocalityUsers { get; set; } = new List<User>();

        public virtual IList<SportEvent> LocalitySportEvents { get; set; } = new List<SportEvent>();

        public virtual IList<SportClub> LocalitySportClubs { get; set; } = new List<SportClub>();
    }
}
