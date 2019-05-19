using System.Web.Mvc;
using SJOne.Models.EventViewModels;
using SJOne.Models.Filters;
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
        



        



    }
}