using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class JudgeMap: ClassMap<Judge>
    {
        public JudgeMap()
        {
            Id(j => j.Id);
            Map(j => j.CountAthlete).Length(2);
            Map(j => j.Ready);
            HasMany(j => j.MainRaces).Inverse();
            HasManyToMany(j => j.Races).Table("Judge_Race")
                .ParentKeyColumn("Judge_id")
                .ChildKeyColumn("Race_id");
            HasMany(j => j.HandTimingsJudge);
            HasMany(j => j.AutoTimingsJudge);
            HasMany(j => j.StartNumbersJudge);
            HasMany(r => r.Protocols);
            HasOne(j => j.User);
        }
    }
}
