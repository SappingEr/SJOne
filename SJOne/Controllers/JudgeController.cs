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

        public JudgeController(JudgeRepository judgeRepository, UserRepository userRepository) : base(userRepository)
        {
            this.judgeRepository = judgeRepository;
        }

        
        public ActionResult Manage(long id)
        {
            var judge = judgeRepository.Get(id);
            return View(judge);
        }

        [HttpGet]
        public ActionResult HTiming(HandTiming timing)
        {
            return View(timing);
        }

        //[HttpPost]
        //public ActionResult HTiming(long id, int startNum)
        //{
        //    var judge = judgeRepository.Get(id);
        //    judge.Race.
        //}
    }
}