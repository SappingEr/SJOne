namespace SJOne.Models
{
    public class Judge
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual Race Race { get; set; }
    }
}