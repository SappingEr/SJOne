using System.Collections.Generic;
using System.Web.Mvc;
using SJOne.Models;
using SJOne.Models.EventViewModels;
using SJOne.Models.Filters;
using SJOne.Models.RaceViewModels;
using SJOne.Models.Repositories;

namespace SJOne.Controllers
{
    public class SportEventController: BaseController
    {

        private SportEventRepository sportEventRepository;
        private RaceRepository raceRepository;        

        public SportEventController(UserRepository userRepository, SportEventRepository sportEventRepository, RaceRepository raceRepository)
            : base(userRepository)
        {
            this.sportEventRepository = sportEventRepository;
            this.raceRepository = raceRepository;
        }

        public ActionResult Index(SportEventListViewModel eventList,SportEventFilter eventFilter, FetchOptions options)
        {
            eventList.SportEvents = sportEventRepository.Find(eventFilter, options);
            return View(eventList);
        }
        public ActionResult RaceList(long id, EventRaceListViewModel eventRaceList)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null)
            {
                eventRaceList.Races = sportEvent.RacesEvent;
                return View(eventRaceList);
            }

            return HttpNotFound("Событие не найдено");
        }
        



        [HttpGet]
        public ActionResult CreateRace(long id) => View(new RaceViewModel { Id = id });

        [HttpPost]
        public ActionResult CreateRace(long id, RaceViewModel raceModel)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null)
            {                    
                raceRepository.InvokeInTransaction(() =>
                {
                    Race race = new Race();
                    race.Name = raceModel.Name;
                    race.Distance = raceModel.Distance;
                    race.LapCount = raceModel.LapCount;
                    race.SportEvent = sportEvent;
                });
                return RedirectToAction("RaceList", "SportEvent", new { id });
            }
            return HttpNotFound();
        }



    }
}