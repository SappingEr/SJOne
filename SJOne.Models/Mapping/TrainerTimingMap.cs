using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    class TrainerTimingMap: ClassMap<TrainerTiming>
    {
        public TrainerTimingMap()
        {
            Id(t => t.Id).GeneratedBy.Increment();
            Map(t => t.Free);
            Map(t => t.Lap).Length(5);
            Map(t => t.LapTime);
            Map(t => t.TotalTime);
            Map(t => t.TimeStamp);
            References(t => t.User);
            References(t => t.Trainer);
        }
        
    }
}
