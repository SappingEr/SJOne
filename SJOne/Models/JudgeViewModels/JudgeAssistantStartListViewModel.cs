using System.Collections.Generic;

namespace SJOne.Models.JudgeViewModels
{
    public class JudgeAssistantStartListViewModel
    {
        public int AthletesCount { get; set; }

        public IEnumerable<StartNumber> AssistantStartList { get; set; }        
    }
}