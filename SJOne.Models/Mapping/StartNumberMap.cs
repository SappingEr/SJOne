﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class StartNumberMap : ClassMap<StartNumber>
    {
        public StartNumberMap()
        {
            Id(s => s.Id);
            Map(s => s.Number).Length(5);
            References(s => s.User).Cascade.All();
            References(s => s.Race); 
            References(s => s.Judge).Cascade.SaveUpdate();
            HasMany(s => s.HandTimingsNumber).Cascade.SaveUpdate();
        }
    }
}
