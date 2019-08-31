using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class GenderMap: ClassMap<Gender>
    {
        public GenderMap()
        {
            Id(g => g.Id);
            Map(g => g.Name).Length(10);
            HasMany(g => g.Users);
            HasMany(g => g.AgeGroups);
        }
    }
}
