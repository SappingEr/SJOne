using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class RegionMap: ClassMap<Region>
    {
        public RegionMap()
        {
            Id(r => r.Id);
            Map(r => r.Name).Length(50);
            References(r => r.Country).Cascade.SaveUpdate();
            HasMany(r => r.Localities);            
;        }
    }
}
