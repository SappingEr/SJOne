using System.Web.Mvc;
using SJOne.Models.Repositories;
using SJOne.Models;
using SJOne.Models.Filters;
using SJOne.Models.JudgeViewModels;
using System.Linq;
using System;
using System.Globalization;

namespace SJOne.Controllers
{
    public class JudgeController : BaseController
    {
        private RaceRepository raceRepository;
        private StartNumberRepository startNumberRepository;
        private HandTimingRepository handTimingRepository;
        private RegionRepository regionRepository;
        private SportClubRepository clubRepository;
       

        public JudgeController(StartNumberRepository startNumberRepository, RaceRepository raceRepository,
            HandTimingRepository handTimingRepository, UserRepository userRepository, RegionRepository regionRepository,
            SportClubRepository clubRepository) : base(userRepository)
        {
            this.raceRepository = raceRepository;
            this.startNumberRepository = startNumberRepository;
            this.handTimingRepository = handTimingRepository;
            this.regionRepository = regionRepository;
            this.clubRepository = clubRepository;           
        }

        public ActionResult StartListSettings(long id, StartListSettingsViewModel startListModel)
        {
            var race = raceRepository.Get(id);
            if (race != null)
            {
                startListModel.Id = id;
                var judges = race.JudgesRace;
                if (judges.Count >= 1)
                {
                    var judgeId = judges.Select(j => j.Id).First();
                    startListModel.JudgeId = judgeId;
                    startListModel.Judges = race.JudgesRace
                        .Select(j => new SelectListItem { Value = j.Id.ToString(), Text = j.User.Surname + " " + j.User.Name });
                }        
                

                startListModel.AgeGroups = race.AgeGroups
                    .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name });
                return View(startListModel);
            }
            return HttpNotFound("Старт не найден");
        }

        public ActionResult StartList(long id,
                                      long? ageGroupId,
                                      string genderId,
                                      Page? page,
                                      UserFilter userFilter,
                                      StartListViewModel startListModel,
                                      int setFirst = 0)
        {
            var race = raceRepository.Get(id);
            int setMax = 5;            
            var athletes = userRepository.StartList(setFirst, setMax, race, userFilter);
            if (athletes.Count() >= 1)
            {
                startListModel.AthletesCount = race.StartNumbersRace.Select(u => u.User).Count();
                startListModel.Id = id;
                startListModel.SetMax = setMax;
                startListModel.Athletes = athletes;
                startListModel.SetFirst = setFirst + 1;
                if (page == Page.Next || page == null)
                {                    
                    startListModel.Items = setFirst + setMax;
                }
                else if(page == Page.Previous)
                {                    
                    startListModel.Items = setFirst + setMax;
                }

                return PartialView(startListModel);
            }
            return ViewBag.Message("Нет зарегистрированных участников.");


        }

        public ActionResult JudgeAssistantStartList(long id, long judgeId, JudgeAssistantStartListViewModel assistListModel)
        {
            var race = raceRepository.Get(id);
            var judge = userRepository.Get(judgeId).Judge;
            assistListModel.AssistantStartList = race.StartNumbersRace.Where(j => j.Judge == judge);
            return PartialView(assistListModel);
        }

        public ActionResult MainRaceList(long id, JudgeRacesViewModel judgeModel)
        {
            var judgeMainRaces = userRepository.Get(id).Judge.MainRaces;
            if (judgeMainRaces != null)
            {
                judgeModel.JudgeRaces = judgeMainRaces;
                return View(judgeModel);
            }
            return RedirectToAction("Index", "Judge", new { id });
        }

        public ActionResult RaceList(long id, JudgeRacesViewModel judgeModel)
        {
            var judgeRaces = userRepository.Get(id).Judge.Races;
            if (judgeRaces != null)
            {
                judgeModel.JudgeRaces = judgeRaces;
                return View(judgeModel);
            }
            return RedirectToAction("Index", "Judge", new { id });
        }

        public ActionResult FindAthlete(long id, UserFilter userFilter, FetchOptions options, FindAthleteViewModel athletesModel)
        {
            var race = raceRepository.Get(id);
            if (race != null)
            {
                athletesModel.Id = id;
                if (userFilter.Name != null || userFilter.Surname != null || userFilter.DOB != null)
                {
                    var athletes = userRepository.Find(userFilter, options);
                    var athletesCount = athletes.Count;
                    if (athletesCount >= 1)
                    {
                        athletesModel.Athletes = athletes;
                        athletesModel.Message = "Выберите спортсмена для регистрации в соревновании";
                        return View(athletesModel);
                    }
                    else if (athletesCount == 0)
                    {
                        athletesModel.Button = true;
                        athletesModel.Message = "Добавить нового участника?";
                        return View(athletesModel);
                    }

                }
                athletesModel.Message = "Введите данные для поиска";
                return View(athletesModel);
            }
            return HttpNotFound("Старт не найден");
        }


        public ActionResult Register(long id, long athleteId)
        {
            var race = raceRepository.Get(id);
            if (race != null)
            {
                var startNumbers = race.StartNumbersRace;
                var freeNumbers = startNumbers.Where(i => i.User == null).ToList();
                if (startNumbers.Count >= freeNumbers.Count)
                {
                    var freeNumber = freeNumbers.First();
                    var judge = race.MainJudgeRace;
                    var athlete = userRepository.Get(athleteId);
                    freeNumber.Judge = judge;
                    freeNumber.User = athlete;
                    raceRepository.InvokeInTransaction(() =>
                    {
                        raceRepository.Save(race);
                    });
                    return RedirectToAction("wdwdwdwd");
                }
            }
            return HttpNotFound("Старт не найден");
        }

        [HttpGet]
        public ActionResult AddNewAthlete(long id)
        {
            var race = raceRepository.Get(id);
            if (race != null)
            {

                var sportEventLocality = race.SportEvent.Locality;
                var sportEventRegion = sportEventLocality.Region;
                var localityId = sportEventLocality.Id;
                var regionId = sportEventLocality.Region.Id;
                var model = new AddAthleteViewModel
                {
                    LocalityId = sportEventLocality.Id,
                    RegionId = regionId
                };
                //model.Genders = genderRepository.FindAll().Select(g=> new SelectListItem { Value = g.Id.ToString(), Text = g.Name });
                model.RegionId = sportEventRegion.Id;
                model.Clubs = clubRepository.FindAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
                model.Regions = regionRepository.FindAll()
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.RegionId.Equals(regionId) });
                model.Localities = sportEventRegion.Localities
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = model.LocalityId.Equals(localityId) });
                return View(model);
            }
            return HttpNotFound("Старт не найден");
        }

        [HttpPost]
        public ActionResult AddNewAthlete(long id, AddAthleteViewModel addAthleteModel)
        {
            var race = raceRepository.Get(id);
            if (race != null)
            {
                var doubleUser = userRepository.Find(new UserFilter
                {
                    Name = addAthleteModel.Name,
                    Surname = addAthleteModel.Surname,
                    DOB = addAthleteModel.DOB
                });
                if (doubleUser.Count > 0)
                {
                    return RedirectToAction("Contact", "Home");
                }


                var startNumbers = race.StartNumbersRace;
                var freeNumbers = startNumbers.Where(i => i.User == null).ToList();
                if (startNumbers.Count >= freeNumbers.Count)
                {
                    var freeNumber = freeNumbers.First();
                    var judge = race.MainJudgeRace;
                    var textInfo = new CultureInfo("ru-RU").TextInfo;
                    var user = new User
                    {
                        Name = textInfo.ToTitleCase(addAthleteModel.Name),
                        Surname = textInfo.ToTitleCase(addAthleteModel.Surname),
                        DOB = addAthleteModel.DOB,
                        RegistrationDate = DateTime.Now.Date,
                        Locality = regionRepository.Get(addAthleteModel.RegionId).Localities.ToList()
                                    .Where(l => l.Id == addAthleteModel.LocalityId).Single(),
                        Email = addAthleteModel.Email,
                        PhoneNumber = addAthleteModel.PhoneNumber,
                        //Gender = genderRepository.Get(addAthleteModel.GenderId),
                        Judge = new Judge(),
                        Trainer = new Trainer()
                    };

                    if (addAthleteModel.ClubId != null)
                    {
                        user.SportClub = clubRepository.Get(Convert.ToInt64(addAthleteModel.ClubId));
                    }
                    
                    freeNumber.Judge = judge;
                    freeNumber.User = user;
                    raceRepository.InvokeInTransaction(() =>
                    {
                        raceRepository.Save(race);
                    });
                    return RedirectToAction("Home", "Start");
                }
            }
            return HttpNotFound("Старт не найден");
        }


        public ActionResult LocalitiesDropDownList(long id, LocalityDropDownListViewModel localityModel)
        {
            long sportEventLocality = 0;
            localityModel.Localities = regionRepository.Get(id).Localities
                .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = localityModel.LocalityId.Equals(sportEventLocality) });
            return PartialView(localityModel);
        }

        public ActionResult SportClubDropDownList(SportClubDropDownListViewModel clubModel)
        {
            clubModel.Clubs = clubRepository.FindAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });

            return PartialView(clubModel);
        }

        public ActionResult AddNewSportClub(string name)
        {
            var clubs = clubRepository.FindAll().Select(i => i.Name.ToLower()).ToList();
            if (clubs.Contains(name.ToLower()))
            {
                return Json(new { succcess = false, responseText = "Ошибка! " + name + " есть в списке!" });
            }

            clubRepository.InvokeInTransaction(() =>
            {
                clubRepository.Save(new SportClub { Name = name });
            });
            return Json(new { succcess = true, responseText = "Список спортивных клубов успешно обновлён." });
        }

        public ActionResult AddNewLocality(long id, string name)
        {
            var region = regionRepository.Get(id);
            if (region != null && name != null && name != "")
            {
                var localities = region.Localities.Select(i => i.Name.ToLower()).ToList();

                if (localities.Contains(name.ToLower()))
                {
                    return Json(new { succcess = false, responseText = "Ошибка! " + name + " есть в списке!" });
                }

                regionRepository.InvokeInTransaction(() =>
                {
                    region.Localities.Add(new Locality { Name = name });
                });

                return Json(new { succcess = true, responseText = "Список населённых пунктов успешно обновлён." });
            }
            return Json(new { succcess = false, responseText = "Ошибка! Выберите регион и введите название нового населённого пункта." });
        }

        //public ActionResult AthleteList(long id, StartNumberListViewModel model)
        //{
        //    var judge = judgeRepository.Get(id);
        //    if (judge != null)
        //    {
        //        model.StartNumbers = startNumberRepository.JudgeAthletesList(judge);
        //        model.NumCount = model.StartNumbers.Count;
        //        model.Id = id;
        //        return View(model);
        //    }
        //    return View(model); // Поменять на адрес кабинета.
        //}

        //[HttpGet]
        //public ActionResult OnStart(long id, StartViewModel model)
        //{
        //    var judge = judgeRepository.Get(id);
        //    if (judge != null && User.IsInRole("Judge"))
        //    {
        //        var assistJudges = judge.Race.JudgesRace;
        //        model.Judge = judge;
        //        if (assistJudges.Count > 1)
        //        {
        //            assistJudges.Remove(judge);                   
        //            model.Judges = assistJudges;                    
        //        }
        //        else
        //        {
        //            model.Judges = null;                    
        //        }
        //        return View(model);
        //    }
        //    return HttpNotFound();            
        //}

        //[HttpPost]
        //public ActionResult OnStart(long id)
        //{
        //    var judge = judgeRepository.Get(id);
        //    handTimingRepository.InvokeInTransaction(() =>
        //    {                
        //        var startNumbers = judge.Race.StartNumbersRace;
        //        var timeStart = DateTime.Now;
        //        foreach (var sN in startNumbers)
        //        {
        //            HandTiming handTiming = new HandTiming { TimeStamp = timeStart };
        //            handTiming.StartNumber = sN;
        //            handTiming.Judge = judge;
        //            handTimingRepository.Save(handTiming);
        //        }
        //    });
        //    return RedirectToAction("ButtonList", "Judge");
        //}

        //[HttpGet]
        //public ActionResult HandTiming(long id)
        //{            
        //    return View(new HandTimingViewModel { Id = id });
        //}

        //[HttpPost]
        //public ActionResult HandTiming(long id, bool start)
        //{
        //    handTimingRepository.InvokeInTransaction(() =>
        //    {
        //        var judge = judgeRepository.Get(id);
        //        var startNumbers = judge.StartNumbersJudge;
        //        var timeStart = DateTime.Now;
        //        foreach (var sN in startNumbers)
        //        {
        //            HandTiming handTiming = new HandTiming { TimeStamp = timeStart };
        //            handTiming.StartNumber = sN;
        //            handTiming.Judge = judge;
        //            handTimingRepository.Save(handTiming);
        //        }
        //    });
        //    return RedirectToAction("ButtonList", "Judge");
        //}

        //public ActionResult ButtonList(long id, ButtonListViewModel buttonModel)
        //{
        //    var judge = judgeRepository.Get(id);            
        //    buttonModel.HandTimings = judge.HandTimingsJudge.GroupBy(i => i.StartNumber)
        //        .Select(gr => gr.Where(x => x.Lap == gr.Max(y => y.Lap)).First())
        //        .OrderByDescending(t => t.Lap).ToList();
        //    return PartialView(buttonModel);
        //}





        //[HttpPost]
        //public ActionResult ButtonList(long id, bool start, ButtonClickViewModel model)
        //{
        //    if (start == true)
        //    {
        //        var TimeStart = DateTime.Now;
        //        var sN = judgeRepository.;
        //    }
        //}

    }
}