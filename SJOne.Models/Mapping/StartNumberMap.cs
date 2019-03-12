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
            Id(s => s.Id).GeneratedBy.Identity();

            Map(s => s.Number).Length(5);

            References(s => s.User);

            References(s => s.Race);
        }
    }
}