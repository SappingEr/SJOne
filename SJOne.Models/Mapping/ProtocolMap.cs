using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class ProtocolMap: ClassMap<Protocol>
    {
        public ProtocolMap()
        {
            Id(f => f.Id);
            Map(f => f.Name).Length(100);
            Map(f => f.ProtocolStream).Length(int.MaxValue);
            References(f => f.Judge);            
        }
    }
}
