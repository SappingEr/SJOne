namespace SJOne.Models
{
    public class OnStartUser
    {
        public string ConnectionId { get; set; }

        public string UserNS { get; set; }

        public bool Readiness { get; set; }
    }
}