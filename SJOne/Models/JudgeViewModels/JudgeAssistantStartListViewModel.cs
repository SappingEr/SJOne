using System.Collections.Generic;

namespace SJOne.Models.JudgeViewModels
{
    public class JudgeAssistantStartListViewModel
    {

        public string JudgeAssistant { get; set; }

        public int AthletesCount { get; set; }

        public IEnumerable<StartNumber> AssistantStartList { get; set; }
    }
}