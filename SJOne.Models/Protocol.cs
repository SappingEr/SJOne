using SJOne.Models.Interfaces;

namespace SJOne.Models
{
    public class Protocol
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual byte[] ProtocolStream { get; set; }

        public virtual User Judge { get; set; }
    }
}