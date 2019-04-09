﻿using FluentNHibernate.Mapping;
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
            References(j => j.Race);
            HasMany(j => j.Users);
            HasMany(j => j.HandTimings);
            HasMany(j => j.AutoTimings);
            HasMany(r => r.Protocols);

        }
    }
}
