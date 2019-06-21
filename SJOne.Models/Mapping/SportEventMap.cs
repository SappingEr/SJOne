using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class SportEventMap: ClassMap<SportEvent>
    {
        public SportEventMap()
        {
            Id(e => e.Id);
            Map(e => e.EventName).Length(150);
            Map(e => e.Description).Length(int.MaxValue);
            Map(e => e.EventDate);
            HasMany(e => e.EventFiles).Cascade.All();
            HasMany(e =>e.EventPhotos).Cascade.SaveUpdate();
            HasMany(e => e.RacesEvent).Cascade.SaveUpdate();
            HasManyToMany(e=>e.Tags).Table("SportEvent_Tag").ParentKeyColumn("SportEvent_id")
                .ChildKeyColumn("Tag_id").Cascade.All();

        }



    }
}
