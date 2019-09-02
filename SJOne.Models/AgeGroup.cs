using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class AgeGroup
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
        
        public virtual byte From { get; set; }
        
        public virtual byte To { get; set; }      

        public virtual IList<Race> Races { get; set; } = new List<Race>();
    }
}
