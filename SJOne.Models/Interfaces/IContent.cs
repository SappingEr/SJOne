namespace SJOne.Models.Interfaces
{
    interface IContent
    {
        long Id { get; set; }

        string Name { get; set; }

        string FilePath { get; set; }
    }
}
