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
            Map(r => r.UnitLength);
            Map(r => r.LapCount).Length(5);
            Map(r => r.Kind);
            Map(r => r.StartNumberCount).Length(5);
            Map(r => r.CountdownTime);
            Map(r => r.AgeFromEvent);
            Map(r => r.StartTime);
            Map(r => r.FinishTime);
            References(r => r.SportEvent);
            References(r => r.MainJudgeRace).Cascade.SaveUpdate();
            HasManyToMany(r=>r.AgeGroups).Table("AgeGroup_Race")
                .ParentKeyColumn("Race_id")
                .ChildKeyColumn("AgeGroup_id")
                .Cascade.SaveUpdate();
            HasMany(r => r.StartNumbersRace).Cascade.SaveUpdate();            
            HasManyToMany(r => r.JudgesRace).Table("Judge_Race")
              .ParentKeyColumn("Race_id")
              .ChildKeyColumn("Judge_id");           
        }
    }
}
