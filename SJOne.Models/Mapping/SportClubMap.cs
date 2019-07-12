using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class SportClubMap: ClassMap<SportClub>
    {
        public SportClubMap()
        {
            Id(c => c.Id);
            Map(c => c.Name).Length(50);
            References(c => c.Locality);
            HasMany(c => c.SportClubUsers);
        }
    }
}
