using SJOne.Models.Interfaces;

namespace SJOne.Models
{
    public class EventFile: IContent
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string FilePath { get; set; }

        public virtual SportEvent SportEvent { get; set; }
    }
}