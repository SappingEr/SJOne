using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class TrainerMap: ClassMap<Trainer>
    {
        public TrainerMap()
        {
            Id(t => t.Id);
            Map(t => t.School).Length(50);
            References(t => t.TrainingTr).Cascade.SaveUpdate();
            HasMany(t => t.Groups).Cascade.SaveUpdate();
            HasMany(t => t.TrainerTimingsTr);
            HasOne(t => t.User);
        }
    }
}
