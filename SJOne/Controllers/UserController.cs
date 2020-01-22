using System;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using SJOne.Models;
using SJOne.Models.UserViewModels;
using SJOne.Models.Repositories;
using System.Linq;

namespace SJOne.Controllers
{
    public class UserController : BaseController
    {
        private RegionRepository regionRepository;
        private SportClubRepository clubRepository;

        public UserController(UserRepository userRepository, RegionRepository regionRepository,
            SportClubRepository clubRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
            this.regionRepository = regionRepository;
            this.clubRepository = clubRepository;
        }

        [HttpGet]
        public ActionResult Info(long id, InfoUserViewModel infoModel)
        {
            var user = userRepository.Get(id);
            var currentUserId = User.Identity.GetUserId();
            if (user != null && id.ToString() == currentUserId)
            {
                infoModel.Id = id;
                infoModel.Avatar = user.Avatar;
                infoModel.Email = user.Email;
                infoModel.Name = user.Name;
                infoModel.Surname = user.Surname;
                infoModel.Locality = user.Locality.Name + " " + user.Locality.Region.Name;
                infoModel.Club = user.SportClub.Name;
                infoModel.DOB = user.DOB;
                infoModel.Gender = user.Gender.ToString();
                return View(infoModel);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult UploadAvatar(AvatarViewModel avatarView, long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                avatarView.Id = id;
                return PartialView(avatarView);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadAvatar(AvatarViewModel avatarView, HttpPostedFileBase imageFile, long id)
        {
            if (imageFile != null)
            {
                avatarView.Avatar = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(avatarView.Avatar, 0, imageFile.ContentLength);
                userRepository.InvokeInTransaction(() =>
                {
                    var user = userRepository.Get(id);
                    user.Avatar = avatarView.Avatar;
                });
                return RedirectToAction("Info", new { id });
            }
            return View(avatarView);
        }

        [HttpGet]
        public ActionResult Gender(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                return View(new GenderViewModel { Id = id });
            }
            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gender(GenderViewModel genderModel)
        {
            var user = userRepository.Get(genderModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.Gender = genderModel.Gender;
            });
            if (user.Name != null && user.Surname != null)
            {
                return RedirectToAction("Info", new { genderModel.Id });
            }
            else
            {
                return RedirectToAction("Data", new { genderModel.Id });
            }
        }


        [HttpGet]
        public ActionResult Data(long id)
        {
            var user = userRepository.Get(id);

            if (user != null)
            {
                EditUserViewModel model = new EditUserViewModel();

                if (user.Name != null && user.Surname != null && user.DOB != null)
                {
                    model.Id = id;
                    model.Name = user.Name;
                    model.Surname = user.Surname;
                    model.DOB = user.DOB;
                    return View(model);
                }
                else
                {
                    model.Id = id;
                    return View(model);
                }
            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Data(EditUserViewModel userModel)
        {
            var user = userRepository.Get(userModel.Id);
            userRepository.InvokeInTransaction(() =>
            {
                user.Name = userModel.Name;
                user.Surname = userModel.Surname;
                user.DOB = userModel.DOB;
            });

            if (user.Locality != null)
            {
                return RedirectToAction("Info", new { userModel.Id });
            }
            else
            {
                return RedirectToAction("Locality", new { userModel.Id });
            }

        }

        [HttpGet]
        public ActionResult Locality(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                LocalityViewModel model = new LocalityViewModel { Id = id };

                if (user.Locality == null)
                {
                    model.Regions = regionRepository.FindAll()
                        .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name });
                }

                else
                {
                    var regionId = user.Locality.Region.Id;
                    model.RegionId = regionId;

                    model.Regions = regionRepository.FindAll()
                        .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.RegionId.Equals(regionId) });
                }

                return View(model);
            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Locality(LocalityViewModel localityModel)
        {
            var user = userRepository.Get(localityModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.Locality = regionRepository.Get(localityModel.RegionId).Localities
                                    .Where(l => l.Id == localityModel.LocalityId).FirstOrDefault();
            });

            if (localityModel.Club == true)
            {
                return RedirectToAction("Club", new { localityModel.Id });
            }
            else
            {
                return RedirectToAction("Info", new { localityModel.Id });
            }

        }

        [HttpGet]
        public ActionResult Club(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                AddSportClubViewModel model = new AddSportClubViewModel { Id = id };

                var localityId = user.Locality.Id;
                var region = user.Locality.Region;
                var regionId = region.Id;
                model.ClubRegionId = regionId;
                model.ClubLocalityId = localityId;

                model.ClubRegions = regionRepository.FindAll()
                   .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.ClubRegionId.Equals(regionId) });

                model.ClubLocalities = region.Localities
                   .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = model.ClubLocalityId.Equals(localityId) });

                var locality = region.Localities.Where(l => l.Id.Equals(localityId)).FirstOrDefault();

                model.Clubs = locality.LocalitySportClubs
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });

                return PartialView(model);
            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Club(AddSportClubViewModel clubViewModel)
        {
            var user = userRepository.Get(clubViewModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.SportClub = clubRepository.Get(Convert.ToInt64(clubViewModel.ClubId));
            });

            return RedirectToAction("Info", new { clubViewModel.Id });
        }        

        [HttpGet]
        public ActionResult AddNewLocality(long id, string name)
        {
            var region = regionRepository.Get(id);
            if (region != null && name != null && name.Length == 0)
            {
                var localities = region.Localities.Select(i => i.Name.ToLower()).ToList();

                if (localities.Contains(name.ToLower()))
                {
                    return Json(new { success = false, responseText = "Ошибка! " + name + " есть в списке!" });
                }

                regionRepository.InvokeInTransaction(() =>
                {
                    region.Localities.Add(new Locality { Name = name });
                });
                return Json(new { success = true, responseText = "Список населённых пунктов успешно обновлён." });
            }
            return Json(new { success = false, responseText = "Ошибка! Выберите регион и введите название нового населённого пункта." });
        }

        [HttpGet]
        public ActionResult SportClub(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                AddSportClubViewModel model = new AddSportClubViewModel { Id = id };
                var region = user.Locality.Region;
                if (region != null)
                {
                    var regionId = region.Id;
                    var localityId = user.Locality.Id;
                    model.ClubRegionId = regionId;
                    model.ClubLocalityId = localityId;

                    model.ClubRegions = regionRepository.FindAll()
                       .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.ClubRegionId.Equals(regionId) });

                    model.ClubLocalities = region.Localities
                       .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = model.ClubLocalityId.Equals(localityId) });

                    var locality = region.Localities.Where(l => l.Id.Equals(localityId)).FirstOrDefault();

                    model.Clubs = locality.LocalitySportClubs
                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
                }


            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SportClub()
        {

        }

        [HttpGet]
        public ActionResult AddNewSportClub(long id, long localityId, string name)
        {
            var region = regionRepository.Get(id);
            var locality = region.Localities.Where(l => l.Id.Equals(localityId)).FirstOrDefault();
            if (region != null && locality != null)
            {
                var clubs = locality.LocalitySportClubs.Select(c => c.Name.ToLower()).ToList();
                if (clubs.Contains(name.ToLower()))
                {
                    return Json(new { success = false, responseText = "Ошибка! " + name + " есть в списке!" });
                }

                if (name != null)
                {
                    locality.LocalitySportClubs.Add(new SportClub { Name = name });
                    regionRepository.InvokeInTransaction(() =>
                    {
                        regionRepository.Save(region);
                    });
                    return Json(new { success = true, responseText = "Список спортивных клубов успешно обновлён." });
                }
                return Json(new { success = false, responseText = "Ошибка! Введите клуб!" });
            }
            return Json(new { success = false, responseText = "Ошибка! Не найден населенный пункт и регион." });
        }
        //[HttpGet]
        //public ActionResult ChangePassword(long id)
        //{
        //    var user = userRepository.Load(id);
        //    if (user != null)
        //    {
        //        return PartialView(new ChangePassViewModel());
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]        
        //public ActionResult ChangePassword(long id, ChangePassViewModel changeModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = userRepository.Load(id);
        //        var changePass = UserManager.ChangePasswordAsync(user.Id, changeModel.Password, changeModel.NewPassword);
        //        if (changePass.Result.Succeeded)
        //        {
        //            return RedirectToAction("Info", new { id });
        //        }
        //    }                      
        //    return View(changeModel);
        //}


        [HttpGet]
        public ActionResult LocalitiesDropDownList(long id, LocalitiesDropDownListViewModel localityModel)
        {
            long localitySelect = 0;
            localityModel.Localities = regionRepository.Get(id).Localities
                .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = localityModel.LocalityId.Equals(localitySelect) });
            return PartialView(localityModel);
        }

        [HttpGet]
        public ActionResult SportClubDropDownList(long id, long? localityId, SportClubDropDownListViewModel clubModel)
        {
            var localities = regionRepository.Get(id).Localities;

            if (localityId == null)
            {
                var clubs = localities.FirstOrDefault().LocalitySportClubs.ToList();
                if (clubs != null)
                {
                    clubModel.Clubs = clubs.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
                }

                return PartialView(clubModel);
            }
            var clubsLocality = localities.Where(l => l.Id.Equals(localityId)).FirstOrDefault();
            clubModel.Clubs = clubsLocality.LocalitySportClubs.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            return PartialView(clubModel);
        }

    }
}