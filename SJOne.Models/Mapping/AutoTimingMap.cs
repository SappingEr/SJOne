using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class AutoTimingMap: ClassMap<AutoTiming>
    {
        public AutoTimingMap()
        {
            Id(a => a.Id).GeneratedBy.Increment();            
            Map(a => a.Lap).Length(5);            
            Map(a => a.LapTime);
            Map(a => a.TotalTime);
            Map(a => a.TimeStamp);
            References(a => a.Judge);
            References(a => a.StartNumber);
        }
    }
}
