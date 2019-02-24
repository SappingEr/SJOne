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
            Map(h => h.StartNumber).Length(10);
            Map(h => h.Lap).Length(5);
            Map(h => h.LapTime);
            References(h => h.Judge);
        }
    }
}
