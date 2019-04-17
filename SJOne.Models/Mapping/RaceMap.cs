using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class RaceMap: ClassMap<Race>
    {
        public RaceMap()
        {
            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.Distance).Length(10);
            Map(r => r.LapCount).Length(5);           
            References(r => r.Event);
            HasMany(r => r.StartNumbers);            
            HasMany(r => r.Judges);
            HasManyToMany(r => r.Users).Table("User_Race")
              .ParentKeyColumn("Race_id")
              .ChildKeyColumn("User_id");
        }
    }
}
