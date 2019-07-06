using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class CityMap: ClassMap<City>
    {
        public CityMap()
        {
            Id(c => c.Id);
            Map(c => c.Name).Length(50);
            References(c => c.Region).Cascade.All();
        }
    }
}
