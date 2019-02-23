using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class RunningEventMap: ClassMap<RunningEvent>
    {
        public RunningEventMap()
        {
            Id(e => e.Id).GeneratedBy.Identity();
            Map(e => e.Name).Length(100);
            Map(e => e.Description).Length(int.MaxValue);
            Map(e => e.EventDate);
            HasMany(e => e.EventFiles);
            HasMany(e => e.Races);

        }



    }
}
