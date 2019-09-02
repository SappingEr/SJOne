using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class AgeGroupMap : ClassMap<AgeGroup>
    {
        public AgeGroupMap()
        {
            Id(a => a.Id);
            Map(a => a.Name).Length(20);
            Map(a => a.From);
            Map(a => a.To);          
            HasManyToMany(a => a.Races).Table("AgeGroup_Race")
                .ParentKeyColumn("AgeGroup_id")
                .ChildKeyColumn("Race_id");
        }
        
    }
}
