namespace SJOne.Models.Filters
{
    public class JudgeFilter: BaseFilter
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        public DateRange Date { get; set; }
    }
}
