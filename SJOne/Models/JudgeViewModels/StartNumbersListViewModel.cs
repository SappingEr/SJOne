using System.Collections.Generic;

namespace SJOne.Models.JudgeViewModels
{
    public class StartNumbersListViewModel
    {
        public long Id { get; set; }

        public IEnumerable<StartNumber> StartNumbers { get; set; }
    }
}