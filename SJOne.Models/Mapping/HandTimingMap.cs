using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class HandTimingMap: ClassMap<HandTiming>
    {
        public HandTimingMap()
        {
            Id(h => h.Id).GeneratedBy.Increment();            
            Map(h => h.Lap).Length(5);
            Map(h => h.LapTime);
            Map(h => h.TotalTime);
            Map(h => h.TimeStamp);
            References(h => h.Judge);
            References(h => h.StartNumber);
        }
    }
}
