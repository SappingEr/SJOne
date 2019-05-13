using SJOne.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class EventPhoto: IContent
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
        
        public virtual string FilePath { get; set; }

        public virtual SportEvent SportEvent { get; set; }

    }
}
