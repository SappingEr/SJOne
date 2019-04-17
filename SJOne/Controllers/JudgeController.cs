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
        private HandTimingRepository hTimingRepository;

        public JudgeController(JudgeRepository judgeRepository, HandTimingRepository hTimingRepository, UserRepository userRepository) : base(userRepository)
        {
            this.judgeRepository = judgeRepository;
            this.hTimingRepository = hTimingRepository;
        }


        public ActionResult JudgeList(long id, JudgeAthletesListViewModel model)
        {
            var judge = judgeRepository.Get(id);
            var race = judge.Race;
            var athletes = userRepository.JudgeAthletesList(judge, race);
            model.Athletes = athletes;
            model.AthleteCount = athletes.Count();
            int[] sN = race.StartNumbers.Select(n=>n.Number).ToArray();
            return View(model);
        }

        [HttpGet]
        public ActionResult HandTiming(long id, HandTimingIndexViewModel timingModel)
        {
            var judge = judgeRepository.Get(id);
            timingModel.HandTimings = judge.HandTimings.GroupBy(i => i.StartNumber)
                .Select(gr => gr.Where(x => x.Lap == gr.Max(y => y.Lap)).First())
                .OrderByDescending(t=>t.Lap).ToList();
            return View(timingModel);
        }

        [HttpPost]
        public ActionResult HandTiming()
        {

        }

    }
}