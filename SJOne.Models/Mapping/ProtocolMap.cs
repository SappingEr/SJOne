using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class ProtocolMap: ClassMap<Protocol>
    {
        public ProtocolMap()
        {
            Id(f => f.Id);
            Map(f => f.ProtocolName).Length(100);
            Map(f => f.FilePath).Length(100);
            References(f => f.Judge);            
        }
    }
}
