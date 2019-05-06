using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class JudgeMap: SubclassMap<Judge>
    {
        public JudgeMap()
        {            
            Map(j => j.CountAthlete).Length(2);
            Map(j => j.Ready);
            Map(j => j.TimerDelay);
            References(j => j.Race);
            HasMany(j => j.HandTimingsJ);
            HasMany(j => j.AutoTimings);
            HasMany(j => j.StartNumbersJ);
            HasMany(r => r.Protocols);

        }
    }
}
