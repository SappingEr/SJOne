using SJOne.Models;
using SJOne.Models.Filters;
using SJOne.Models.RaceViewModels;
using SJOne.Models.Repositories;
using System;
using System.Linq;
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
            if (race != null)
            {
                long[] userId = race.UsersRace.Select(i => i.Id).ToArray();
                var athleteList = userRepository.RaceAthletesList(userId, race, userFilter, options);
                model.Id = race.Id;
                model.Athletes = athleteList;
                model.AthleteCount = athleteList.Count;
                model.JudgeCount = Convert.ToInt32(Math.Ceiling(athleteList.Count / 10.0));
                model.Distance = race.Distance;
                model.LapCount = race.LapCount;
                return View(model);
            }
            return HttpNotFound("Забег не найден");

        }

        [HttpGet]
        public ActionResult AddAthlete(long id) => View(new AthleteViewModel { Id = id });

        [HttpPost]
        public ActionResult AddAthlete(long id, AthleteViewModel athleteModel)
        {
            var race = raceRepository.Get(id);

            if (race != null)
            {
                var user = new User();
                userRepository.InvokeInTransaction(() =>
                {
                    user.Name = athleteModel.Name;
                    user.Surname = athleteModel.Surname;
                    user.City = athleteModel.City;
                    user.Club = athleteModel.Club;
                    user.DOB = athleteModel.DOB;
                    user.RegistrationDate = DateTime.Now;
                    race.UsersRace.Add(user);
                    userRepository.Save(user);
                });
                return RedirectToAction("StartList", "Race", new { id });
            }
            return RedirectToAction("AddAthlete", "Race", new { id });
        }
    }
}