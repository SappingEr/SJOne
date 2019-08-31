using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Tag
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<SportEvent> SportEvents { get; set; } = new List<SportEvent>();
    }
}
