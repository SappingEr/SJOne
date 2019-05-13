using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class EventPhotoMap: ClassMap<EventPhoto>
    {
        public EventPhotoMap()
        {
            Id(p => p.Id);
            Map(p => p.Name).Length(100);
            Map(p => p.FilePath).Length(100);
            References(p => p.SportEvent);
        }
    }
}
