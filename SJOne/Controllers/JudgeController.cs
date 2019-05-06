using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJOne.Models;
using SJOne.Models.Repositories;

namespace SJOne.Controllers
{
    public class JudgeController : BaseController
    {
        private JudgeRepository judgeRepository;
        private StartNumberRepository startNumberRepository;
        private HandTimingRepository handTimingRepository;

        public JudgeController(JudgeRepository judgeRepository, StartNumberRepository startNumberRepository, 
            HandTimingRepository handTimingRepository, UserRepository userRepository) : base(userRepository)
        {
            this.judgeRepository = judgeRepository;
            this.startNumberRepository = startNumberRepository;
            this.handTimingRepository = handTimingRepository;
        }


        public ActionResult JudgeList(long id, JudgeAthletesListViewModel model)
        {
            var judge = judgeRepository.Get(id);
            var race = judge.Race;
            var athletes = userRepository.JudgeAthletesList(judge);
            model.AthleteCount = model.Athletes.Count;            
            return View(model);
        }

        [HttpGet]
        public ActionResult OnStart(StartViewModel model)
        {
            var judge = (Judge)userRepository.GetCurrentUser();
            if (judge != null)
            {
                var assistJudges = judge.Race.Judges;
                model.Judge = judge;
                if (assistJudges.Count > 1)
                {
                    assistJudges.Remove(judge);                   
                    model.Judges = assistJudges;                    
                }
                else
                {
                    model.Judges = null;                    
                }
                return View(model);
            }
            return HttpNotFound();            
        }

        [HttpPost]
        public ActionResult OnStart(long id)
        {
            var judge = judgeRepository.Get(id);
            handTimingRepository.InvokeInTransaction(() =>
            {                
                var startNumbers = judge.Race.StartNumbersR;
                var timeStart = DateTime.Now;
                foreach (var sN in startNumbers)
                {
                    HandTiming handTiming = new HandTiming { TimeStamp = timeStart };
                    handTiming.StartNumber = sN;
                    handTiming.Judge = judge;
                    handTimingRepository.Save(handTiming);
                }
            });
            return RedirectToAction("ButtonList", "Judge");
        }

        [HttpGet]
        public ActionResult HandTiming(long id)
        {            
            return View(new HandTimingViewModel { Id = id });
        }

        [HttpPost]
        public ActionResult HandTiming(long id, bool start)
        {
            handTimingRepository.InvokeInTransaction(() =>
            {
                var judge = judgeRepository.Get(id);
                var startNumbers = judge.StartNumbersJ;
                var timeStart = DateTime.Now;
                foreach (var sN in startNumbers)
                {
                    HandTiming handTiming = new HandTiming { TimeStamp = timeStart };
                    handTiming.StartNumber = sN;
                    handTiming.Judge = judge;
                    handTimingRepository.Save(handTiming);
                }
            });
            return RedirectToAction("ButtonList", "Judge");
        }




        public ActionResult ButtonList(long id, ButtonListViewModel buttonModel)
        {
            var judge = judgeRepository.Get(id);            
            buttonModel.HandTimings = judge.HandTimingsJ.GroupBy(i => i.StartNumber)
                .Select(gr => gr.Where(x => x.Lap == gr.Max(y => y.Lap)).First())
                .OrderByDescending(t => t.Lap).ToList();
            return PartialView(buttonModel);
        }

        //[HttpPost]
        //public ActionResult ButtonList(long id, bool start, ButtonClickViewModel model)
        //{
        //    if (start == true)
        //    {
        //        var TimeStart = DateTime.Now;
        //        var sN = judgeRepository.;
        //    }
        //}

    }
}