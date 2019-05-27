using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class SubGroupMap: ClassMap<SubGroup>
    {
        public SubGroupMap()
        {
            Id(sG => sG.Id);
            Map(sG => sG.SubGrName).Length(50);
            Map(sG => sG.SubGrDescription).Length(int.MaxValue);
            References(sG => sG.Group);
            HasMany(sG => sG.TimingsSubGr).Cascade.SaveUpdate();
        }
    }
}
