using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Region
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual IList<Locality> Localities { get; set; } = new List<Locality>();           
    }
}
