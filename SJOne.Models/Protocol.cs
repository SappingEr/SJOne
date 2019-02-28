namespace SJOne.Models
{
    public class Protocol
    {
        public virtual long Id { get; set; }

        public virtual string ProtocolName { get; set; }

        public virtual string FilePath { get; set; }

        public virtual Judge Judge { get; set; }
    }
}