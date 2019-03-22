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

        
        public ActionResult Manage(long id)
        {
            var race = raceRepository.Get(id);            
            return View(race);
        }

        //public ActionResult AddAthlete()
        //{
            
        //}

        //[HttpGet]
        //public ActionResult HTiming(long id)
        //{

        //    return View(timing);
        //}
        //[HttpPost]
        //public ActionResult HTiming()
        //{

        //}


        //[HttpPost]
        //public ActionResult HTiming(long id, int startNum)
        //{
        //    var judge = judgeRepository.Get(id);
        //    judge.Race.
        //}
    }
}