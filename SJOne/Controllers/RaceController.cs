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
            var athleteList = userRepository.RaceAthletesList(race, userFilter, options);
            model.Athletes = race.Users;/*athleteList*/;
            model.AthleteCount = athleteList.Count;
            model.JudgeCount = Convert.ToInt32(Math.Ceiling(athleteList.Count / 10.0));
            model.Distance = race.Distance;
            model.LapCount = race.LapCount;
            return View(model);
        }
    }
}