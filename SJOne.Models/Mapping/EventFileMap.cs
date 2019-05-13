using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class EventFileMap: ClassMap<EventFile>
    {
        public EventFileMap()
        {
            Id(f => f.Id);
            Map(f => f.Name).Length(100);
            Map(f => f.FilePath).Length(100);
            References(f => f.SportEvent);
        }
    }
}
