using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class JudgeMap: ClassMap<Judge>
    {
        public JudgeMap()
        {
            Id(j => j.Id).GeneratedBy.Identity();
            Map(j => j.Name).Length(50);
            Map(j => j.Surname).Length(50);
            References(j => j.Race);
            HasMany(j => j.Users);

        }
    }
}
