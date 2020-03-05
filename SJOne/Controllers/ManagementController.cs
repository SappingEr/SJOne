using SJOne.Models;
using SJOne.Models.Filters;
using SJOne.Models.ManagementViewModels;
using SJOne.Models.Repositories;
using System;
using System.Collections;
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

        [HttpGet]
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
            return HttpNotFound("Событие не найдено");
        }

        [HttpGet]
        public ActionResult CreateRace(long id)
        {
            var sportEvent = sportEventRepository.Get(id);
            if (sportEvent != null)
            {
                return View(new RaceViewModel { Id = id });
            }
            return HttpNotFound("Событие не найдено");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRace(long id, RaceViewModel raceModel)
        {
            var sportEvent = sportEventRepository.Get(id);

            if (ModelState.IsValid)
            {
                Race race = new Race()
                {
                    Name = raceModel.Name,                    
                    Kind = raceModel.Kind                    
                };

                if (raceModel.CountDownTime > 0)
                {
                    race.CountdownTime = raceModel.CountDownTime;
                }
                else
                {
                    race.Distance = raceModel.Distance;
                    race.UnitLength = raceModel.UnitLength;
                }

                sportEvent.RacesEvent.Add(race);

                sportEventRepository.InvokeInTransaction(() =>
                {
                    sportEventRepository.Save(sportEvent);
                });
                return RedirectToAction("AddStartNumbers", "Management", new { race.Id });
            }
            return HttpNotFound("Событие не найдено");
        }

        [HttpGet]
        public ActionResult AddStartNumbers(long id) => View(new StartNumbersAddViewModel { Id = id });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStartNumbers(long id, StartNumbersAddViewModel numbersModel)
        {
           
            if (ModelState.IsValid)
            {
                var race = raceRepository.Get(id);

                List<int> startNumbers = new List<int>();                

                List<int> modelNumbers = new List<int>();
                var initStartNumber = Convert.ToInt32(numbersModel.InitialStartNumber);
                var finalStartNumber = Convert.ToInt32(numbersModel.FinalStartNumber);

                for (int i = initStartNumber; i <= finalStartNumber; i++)
                {
                    modelNumbers.Add(i);
                }

                if ((numbersModel.From > 0 && numbersModel.From > 0) || numbersModel.ExNumbers != null)
                {
                    List<int> exRow = new List<int>();

                    List<int> exNumbers = new List<int>();

                    if (numbersModel.From > 0 && numbersModel.From > 0)
                    {
                        var exFrom = Convert.ToInt32(numbersModel.From);
                        var exTo = Convert.ToInt32(numbersModel.To);

                        for (int i = exFrom; i <= exTo; i++)
                        {
                            exRow.Add(i);
                        }
                    }

                    if (numbersModel.ExNumbers != null)
                    {
                        exNumbers = numbersModel.ExNumbers.Split(',').Select(Int32.Parse).ToList();
                    }

                    var numbers = modelNumbers.Except(exRow);

                    startNumbers = numbers.Except(exNumbers).ToList();
                }
                else
                {
                    startNumbers = modelNumbers;
                }

                int startNumberCount = startNumbers.Count;
                race.StartNumberCount = startNumberCount;

                IList<StartNumber> raceStartNumbers = new List<StartNumber>();

                foreach (var i in startNumbers)
                {
                    raceStartNumbers.Add(new StartNumber { Number = i, Race = race });
                }

                race.StartNumbersRace = raceStartNumbers;

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

        [HttpGet]
        public ActionResult AddMainJudge(long raceId, long judgeId)
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