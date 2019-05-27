﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class JudgeMap: ClassMap<Judge>
    {
        public JudgeMap()
        {
            Id(j => j.Id);
            Map(j => j.CountAthlete).Length(2);
            Map(j => j.Ready);            
            References(j => j.Race);
            HasMany(j => j.HandTimingsJudge);
            HasMany(j => j.AutoTimingsJudge);
            HasMany(j => j.StartNumbersJudge);
            HasMany(r => r.Protocols);
            HasOne(j => j.User);
        }
    }
}
