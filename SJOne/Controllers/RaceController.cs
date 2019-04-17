using SJOne.Models;
using SJOne.Models.Filters;
using SJOne.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Controllers
{
    public class RaceController : BaseController
    {
        private RaceRepository raceRepository;

        public RaceController(RaceRepository raceRepository, UserRepository userRepository) :
            base(userRepository)
        {
            this.raceRepository = raceRepository;
        }

        
        public ActionResult StartList(long id, RaceAthletesListViewModel model, UserFilter userFilter, FetchOptions options)
        {
            var race = raceRepository.Get(id);
            long[] userId = race.Users.Select(i=>i.Id).ToArray();
            var athleteList = userRepository.RaceAthletesList(userId, race, userFilter, options);
            model.Athletes = athleteList;
            model.AthleteCount = athleteList.Count;
            model.JudgeCount = Convert.ToInt32(Math.Ceiling(athleteList.Count / 10.0));
            model.Distance = race.Distance;
            model.LapCount = race.LapCount;
            return View(model);
        }
    }
}