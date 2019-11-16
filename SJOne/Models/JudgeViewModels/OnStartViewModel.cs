using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class OnStartViewModel
    {
        public long RaceId { get; set; }

        public long JudgeId { get; set; }

        //User Name + Surname
        public string UserNS { get; set; }

        public string MainJudgeUserName { get; set; }

        //MainJudge Name + Surname
        public string MainJudgeNS { get; set; }

        public string JudgeCount { get; set; }

    }
}