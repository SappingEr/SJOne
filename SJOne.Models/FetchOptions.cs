using System.Web.UI.WebControls;

namespace SJOne.Models.Repositories
{
    public class FetchOptions
    {
        public int Start { get; set; }

        public int Count { get; set; }

        public string SortExpression { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}