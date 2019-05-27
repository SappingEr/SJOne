using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models.Mapping
{
    public class GroupMap: ClassMap<Group>
    {
        public GroupMap()
        {
            Id(g => g.Id);
            Map(g => g.GroupName).Length(50);
            Map(g => g.GroupDescription).Length(int.MaxValue);
            References(g => g.Trainer);
            HasMany(g => g.UsersGroup).Cascade.SaveUpdate();
            HasMany(g => g.SubGroups).Cascade.SaveUpdate();
        }
    }
}
