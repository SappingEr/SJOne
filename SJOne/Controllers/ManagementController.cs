using SJOne.Models;
using SJOne.Models.Filters;
using SJOne.Models.ManagementViewModels;
using SJOne.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Controllers
{
    public class ManagementController : BaseController
    {
        private TagRepository tagRepository;
        private SportEventRepository sportEventRepository;
        private RaceRepository raceRepository;

        public ManagementController(UserRepository userRepository, TagRepository tagRepository, SportEventRepository sportEventRepository, RaceRepository raceRepository)
            : base(userRepository)
        {
            this.tagRepository = tagRepository;
            this.sportEventRepository = sportEventRepository;
            this.raceRepository = raceRepository;
        }

        [HttpGet]
        public ActionResult CreateEvent() => View(new SportEventViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(SportEventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                SportEvent sportEvent = new SportEvent()
                {
                    EventName = eventModel.EventName,
                    Description = eventModel.Description,
                    EventDate = eventModel.EventDate,
                    EndRegDate = eventModel.EndRegDate
                };

                //var modelTags = eventModel.Tags.Where(t => t.Name != null).ToList();
                //List<Tag> modelTags = (from tag in eventModel.Tags
                //                       select new Tag { Name = tag.Name.ToLower() }).ToList();

                List<Tag> eventTags = new List<Tag>();
                eventTags = eventModel.Tags.Where(t => t.Name != null).ToList();

                if (eventTags.Count > 0)
                {
                    List<Tag> tagsNamesToLower = (from tag in eventTags
                                                  select new Tag { Name = tag.Name.ToLower() }).ToList();                    

                    var modelTagNames = tagsNamesToLower.Select(t => t.Name).ToArray();

                    var tags = tagRepository.TagsByNames(modelTagNames);

                    if (tags.Count > 0)
                    {
                        sportEvent.Tags = tags;
                    }

                    if (eventTags.Count > tags.Count)
                    {
                        List<Tag> tagsByNames = new List<Tag>();

                        List<Tag> newTags = new List<Tag>();

                        tagsByNames.AddRange(from t in tags
                                             let tag = tagsNamesToLower.Where(d => d.Name == t.Name).FirstOrDefault()
                                             where tag != null
                                             select tag);

                        newTags = tagsNamesToLower.Except(tagsByNames).ToList();

                        foreach (var newTag in newTags)
                        {
                            sportEvent.Tags.Add(newTag);
                        }
                    }
                    
                }

                sportEventRepository.InvokeInTransaction(() =>
                {
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("EventSettings", "Management", new { sportEvent.Id });
            }
            //Вывести ошибку
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
                eventModel.Photos = sportEvent.EventPhotos;
                eventModel.Tags = sportEvent.Tags;
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

                return RedirectToAction("JudgeList", "Management", new { race.Id });

            }
            return HttpNotFound("Старт не обнаружен!");
        }


        public ActionResult JudgeList(long id, JudgeListViewModel judgeModel, UserFilter userFilter, FetchOptions options)
        {
            if (raceRepository.Get(id) != null)
            {
                judgeModel.Id = id;
                judgeModel.Judges = userRepository.FindUsersInRole("Judge", userFilter, options);
                return View(judgeModel);
            }
            return HttpNotFound("Старт не обнаружен!");
        }

        public ActionResult AddJudge(long raceId, long judgeId)
        {
            var race = raceRepository.Get(raceId);
            var judge = userRepository.Get(judgeId);
            if (race != null && judge != null)
            {
                raceRepository.InvokeInTransaction(() =>
                {
                    race.MainJudgeRace = judge;
                });
                return RedirectToAction("EventSettings", "Management", new { race.SportEvent.Id });
            }
            return HttpNotFound("Старт не обнаружен!");
        }

        public ActionResult UploadEventPhotos(long id)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null)
            {
                return View(new UploadEventContentViewModel { Id = id });
            }
            return HttpNotFound("Событие не обнаружено");
        }

        [HttpPost]
        public ActionResult UploadEventPhotos(long id, HttpPostedFileBase[] content)
        {
            if (ModelState.IsValid)
            {
                var sportEvent = sportEventRepository.Get(id);
                foreach (var item in content)
                {
                    if (item != null)
                    {
                        string fileName = System.IO.Path.GetFileName(item.FileName);
                        string filePath = "~/Content/Images/" + fileName;
                        item.SaveAs(Server.MapPath(filePath));
                        sportEvent.EventPhotos.Add(new EventPhoto
                        {
                            Name = fileName,
                            FilePath = filePath
                        });
                    }
                }
                sportEventRepository.InvokeInTransaction(() =>
                {
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("EventSettings", "Management", new { sportEvent.Id });

            }
            return ViewBag.Message("Загрузка не удалась");
        }
    }
}