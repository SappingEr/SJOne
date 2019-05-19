using SJOne.Models;
using SJOne.Models.ManagementViewModels;
using SJOne.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SJOne.Controllers
{
    public class ManagementController : BaseController
    {
        private SportEventRepository sportEventRepository;
        private RaceRepository raceRepository;

        public ManagementController(UserRepository userRepository, SportEventRepository sportEventRepository, RaceRepository raceRepository)
            : base(userRepository)
        {
            this.sportEventRepository = sportEventRepository;
            this.raceRepository = raceRepository;
        }

        [HttpGet]
        public ActionResult CreateEvent() => View(new SportEventViewModel());

        [HttpPost]
        public ActionResult CreateEvent(SportEventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                SportEvent sportEvent = new SportEvent()
                {
                    EventName = eventModel.EventName,
                    Description = eventModel.Description,
                    EventDate = eventModel.EventDate
                };
                sportEventRepository.InvokeInTransaction(() =>
                {
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("EventSettings", "Management", new { sportEvent.Id });
            }
            ViewBag.Message = "Валидация не пройдена";
            return View(eventModel);
        }

        public ActionResult EventSettings(long id, SportEventSettingsViewModel eventModel)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null)
            {
                eventModel.EventName = sportEvent.EventName;
                eventModel.Description = sportEvent.Description;
                eventModel.EventDate = sportEvent.EventDate;
                return View(eventModel);
            }
            return HttpNotFound("Событие не обнаружено");
        }

        [HttpGet]
        public ActionResult CreateRace(long id) => View(new RaceViewModel { Id = id });

        [HttpPost]
        public ActionResult CreateRace(long id, RaceViewModel raceModel)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null && ModelState.IsValid)
            {
                Race race = new Race()
                {
                    Name = raceModel.Name,
                    Distance = raceModel.Distance,
                    LapCount = raceModel.LapCount
                };
                sportEvent.RacesEvent.Add(race);
                sportEventRepository.InvokeInTransaction(() =>
                {
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("AddStartNumbers", "Management", new { race.Id });
            }            
            return View(raceModel);
        }

        [HttpGet]
        public ActionResult AddStartNumbers(long id) => View(new StartNumbersAddViewModel { Id = id });

        [HttpPost]
        public ActionResult AddStartNumbers(long id, StartNumbersAddViewModel numbersModel)
        {
            var race = raceRepository.Get(id);
            if (race != null && ModelState.IsValid)
            {
                var sN = 0;
                var startNumberCount = numbersModel.StartNumberCount;
                race.StartNumberCount = startNumberCount;
                IList<StartNumber> startNumbers = new List<StartNumber>();
                for (int i = numbersModel.InitialStartNumber; sN < startNumberCount; i++, sN++)
                {
                    startNumbers.Add(new StartNumber { Number = i, Race = race });
                }

                race.StartNumbersRace = startNumbers;

                raceRepository.InvokeInTransaction(() =>
                {
                    raceRepository.Save(race);
                });

                return RedirectToAction("AddJudge", "Management", new { id });

            }
            return HttpNotFound("Старт не обнаружен!");
        }

        

        //[HttpPost]
        //public ActionResult AddJudge(long id, string userName)
        //{

        //}
    }
}