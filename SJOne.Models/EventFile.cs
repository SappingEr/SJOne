namespace SJOne.Models
{
    public class EventFile
    {
        public virtual long Id { get; set; }

        public virtual string FileName { get; set; }

        public virtual string FilePath { get; set; }

        public virtual Event RunningEvent { get; set; }
    }
}