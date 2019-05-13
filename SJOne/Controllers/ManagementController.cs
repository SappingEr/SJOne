using SJOne.Models;
using SJOne.Models.ManagementViewModels;
using SJOne.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                sportEventRepository.InvokeInTransaction(() =>
                {
                    SportEvent sportEvent = new SportEvent()
                    {
                        EventName = eventModel.EventName,
                        Description = eventModel.Description,
                        EventDate = eventModel.EventDate
                    };
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("Start", "Home");
            }
            ViewBag.Message = "Валидация не пройдена";
            return View(eventModel);
        }





    }
}