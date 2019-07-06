using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class СountryMap: ClassMap<Country>
    {
        public СountryMap()
        {
            Id(c => c.Id);
            Map(c => c.Name).Length(70);
            HasMany(c => c.Regions);
        }
    }
}
