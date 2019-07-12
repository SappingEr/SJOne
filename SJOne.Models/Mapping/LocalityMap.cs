using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class LocalityMap: ClassMap<Locality>
    {
        public LocalityMap()
        {
            Id(c => c.Id);
            Map(c => c.Name).Length(50);
            References(c => c.Region).Cascade.All();
            HasMany(c => c.LocalityUsers);
            HasMany(c => c.LocalitySportEvents);
            HasMany(c => c.LocalitySportClubs);
        }
    }
}
