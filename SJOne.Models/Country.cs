using System.Collections.Generic;

namespace SJOne.Models
{
    public class Country
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Region> Regions { get; set; } = new List<Region>();
    }
}
