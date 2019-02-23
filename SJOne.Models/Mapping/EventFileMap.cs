using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class EventFileMap: ClassMap<EventFile>
    {
        public EventFileMap()
        {
            Id(f => f.Id).GeneratedBy.Identity();
            Map(f => f.FileName).Length(100);
            Map(f => f.FilePath).Length(100);
            References(f => f.RunningEvent);
        }
    }
}
