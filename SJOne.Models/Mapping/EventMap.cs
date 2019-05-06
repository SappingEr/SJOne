using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class EventMap: ClassMap<Event>
    {
        public EventMap()
        {
            Id(e => e.Id);
            Map(e => e.EventName).Length(300);
            Map(e => e.Description).Length(int.MaxValue);
            Map(e => e.EventDate);
            HasMany(e => e.EventFiles);
            HasMany(e => e.Races);

        }



    }
}
