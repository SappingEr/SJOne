using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class SubGroup
    {
        public virtual int Id { get; set; }

        public virtual string SubGrName { get; set; }

        public virtual string SubGrDescription { get; set; }

        public virtual Group Group { get; set; }

        public virtual IList<User> UsersSubGr { get; set; } = new List<User>();

        public virtual IList<TrainerTiming> TimingsSubGr { get; set; } = new List<TrainerTiming>();
       
    }
}
