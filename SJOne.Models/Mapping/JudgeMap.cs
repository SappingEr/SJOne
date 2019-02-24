using FluentNHibernate.Mapping;
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
            Id(j => j.Id).GeneratedBy.Identity();
            Map(j => j.JudgeName).Length(50);
            Map(j => j.JudgeSurname).Length(50);
            HasMany(j => j.Athletes);
            HasMany(j => j.HandTimings);
            HasMany(j => j.AutoTimings);

        }
    }
}
