using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class RaceMap: ClassMap<Race>
    {
        public RaceMap()
        {
            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.LapCount);
            Map(r => r.LapTime);
            Map(r => r.TotalTime);
            References(r => r.RunningEvent);
            HasMany(r => r.Judges);
            HasMany(r => r.Protocols);
            HasManyToMany(a => a.Athletes).Table("Race_Athlete")
               .ParentKeyColumn("Athlete_Id")
               .ChildKeyColumn("Race_Id");

        }
    }
}
