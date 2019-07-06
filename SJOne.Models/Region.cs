using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Region
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual IList<City> Cities { get; set; } = new List<City>();

        public virtual IList<Village> Villages { get; set; } = new List<Village>();        
    }
}
