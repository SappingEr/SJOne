using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class RaceMap: ClassMap<Race>
    {
        public RaceMap()
        {
            Id(r => r.Id);
            Map(r => r.Name).Length(50);
            Map(r => r.Distance).Length(10);
            Map(r => r.LapCount).Length(5);            
            Map(r => r.StartNumberCount).Length(5);
            References(r => r.SportEvent);
            HasMany(r => r.StartNumbersR).Inverse();            
            HasMany(r => r.Judges);
            HasManyToMany(r => r.Users).Table("User_Race")
              .ParentKeyColumn("Race_id")
              .ChildKeyColumn("User_id");
        }
    }
}
