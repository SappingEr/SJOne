using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class TagMap: ClassMap<Tag>
    {
        public TagMap()
        {
            Id(m => m.Id);
            Map(m => m.Name).Length(50);            
            HasManyToMany(m => m.SportEvents).Table("SportEvent_Tag").ParentKeyColumn("Tag_id")
                .ChildKeyColumn("SportEvent_id");
        }
    }
}
