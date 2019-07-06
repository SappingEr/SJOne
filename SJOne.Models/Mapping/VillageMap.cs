using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class VillageMap: ClassMap<Village>
    {
        public VillageMap()
        {
            Id(v => v.Id);
            Map(v => v.Name).Length(50);
            References(v => v.Region);
        }
    }
}
