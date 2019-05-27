using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class TrainingMap: ClassMap<Training>
    {
        public TrainingMap()
        {
            Id(t => t.Id);
            Map(t => t.Name).Length(50);
            Map(t=>t.Description).Length(int.MaxValue);
            Map(t => t.TrainingTime);
            Map(t => t.TrainigDate);
            Map(t => t.Duration);
            HasMany(t => t.UsersTrainig).Cascade.SaveUpdate();
            HasMany(t => t.TrainersTrainig).Cascade.SaveUpdate();
        }
    }
}
