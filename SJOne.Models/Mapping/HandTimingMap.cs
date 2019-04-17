using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class HandTimingMap: ClassMap<HandTiming>
    {
        public HandTimingMap()
        {
            Id(h => h.Id).GeneratedBy.Identity();            
            Map(h => h.Lap).Length(5);
            Map(h => h.LapTime);
            Map(h => h.TotalTime);
            Map(h => h.TimerDelay);            
            References(h => h.Judge);
            References(h => h.StartNumber);
        }
    }
}
