using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class SportClub
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Locality Locality { get; set; }

        public virtual IList<User> SportClubUsers { get; set; } = new List<User>();
    }
}
