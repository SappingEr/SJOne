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
        private RaceRepository raceRepository;

        public JudgeController(JudgeRepository judgeRepository, UserRepository userRepository, RaceRepository raceRepository) : base(userRepository)
        {
            this.judgeRepository = judgeRepository;
            this.raceRepository = raceRepository;
        }


        public ActionResult JudgeList(long id, JudgeAthletesListViewModel model)
        {
            var judge = judgeRepository.Get(id);
            var race = judge.Race;            
            model.Athletes = userRepository.JudgeAthletesList(race, judge);
            model.AthleteCount = judge.Users.Count;
            return View(model);
        }

        public ActionResult Num(long id)
        {
            var judge = judgeRepository.Get(id);
            var race = judge.Race;
            var num = judgeRepository.GetStartNumbers(judge);
            return View(num);
        }
    }
}