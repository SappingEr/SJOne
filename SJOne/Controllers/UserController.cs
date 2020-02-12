using System;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using SJOne.Models;
using SJOne.Models.UserViewModels;
using SJOne.Models.Repositories;
using System.Linq;
using System.Globalization;

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

            if (user != null)
            {
                if (user.Name == null && user.Surname == null && user.Gender == 0)
                {
                    infoModel.EmptyProp = true;
                }

                else
                {
                    infoModel.Id = id;
                    infoModel.Gender = user.Gender;
                    infoModel.Avatar = user.Avatar;
                    infoModel.Data = user.Name + " " + user.Surname + " " + Convert.ToDateTime(user.DOB).ToString("d");
                    if (user.Locality != null)
                    {
                        infoModel.Locality = user.Locality.Name + " | " + user.Locality.Region.Name;
                    }
                    else
                    {
                        infoModel.Locality = "Укажите населённый пункт";
                    }

                    if (user.SportClub != null)
                    {
                        infoModel.Club = user.SportClub.Name;
                    }
                    else
                    {
                        infoModel.Club = "Нет клуба";
                    }
                    infoModel.Email = user.Email;
                    infoModel.PhoneNumber = user.PhoneNumber;
                }

                return View(infoModel);
            }
            return HttpNotFound("Пользователь не найден");
        }

        [HttpGet]
        public ActionResult UploadAvatar(AvatarViewModel model, long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                if (user.Avatar != null)
                {
                    model.Delete = true;
                }
                model.Id = id;
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadAvatar(long id, AvatarViewModel avatarView, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid && imageFile != null)
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

            ModelState.AddModelError("", "Выберите файл!");

            return View(avatarView);
        }

        [HttpGet]
        public ActionResult DeleteAvatar(long id)
        {
            var user = userRepository.Get(id);
            userRepository.InvokeInTransaction(() =>
            {
                user.Avatar = null;
            });

            return RedirectToAction("Info", new { id });
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

            if (ModelState.IsValid)
            {
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

            return View(genderModel);
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

            if (ModelState.IsValid)
            {
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

            return View(userModel);
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
                    var region = user.Locality.Region;
                    var regionId = region.Id;
                    model.RegionId = regionId;

                    model.Regions = regionRepository.FindAll()
                        .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.RegionId.Equals(regionId) });

                    model.Localities = region.Localities.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }

                if (user.SportClub == null)
                {
                    model.AddClub = true;
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
                return RedirectToAction("SportClub", new { localityModel.Id });
            }
            else
            {
                return RedirectToAction("Info", new { localityModel.Id });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewLocality(long id, string name)
        {
            var region = regionRepository.Get(id);
            if (region != null && name != null && name.Length >= 0)
            {
                var localities = region.Localities.Select(i => i.Name.ToLower()).ToList();

                if (localities.Contains(name.ToLower()))
                {
                    return Json(new { success = false, responseText = "Ошибка! " + name + " есть в списке!" });
                }
                else
                {
                    var textInfo = new CultureInfo("ru-RU").TextInfo;
                    var localityName = textInfo.ToTitleCase(name);

                    regionRepository.InvokeInTransaction(() =>
                    {
                        region.Localities.Add(new Locality { Name = localityName });
                    });

                    return Json(new { success = true, responseText = "Список населённых пунктов успешно обновлён." });
                }

            }
            return Json(new { success = false, responseText = "Ошибка! Выберите регион и введите название нового населённого пункта." });
        }

        [HttpGet]
        public ActionResult SportClub(long id)
        {
            var user = userRepository.Get(id);
            var locality = user.Locality;
            if (user != null && locality != null)
            {
                AddSportClubViewModel model = new AddSportClubViewModel { Id = id };

                var region = user.Locality.Region;
                if (region != null)
                {
                    var regionId = region.Id;
                    var localityId = locality.Id;
                    model.ClubRegionId = regionId;
                    model.ClubLocalityId = localityId;

                    model.ClubRegions = regionRepository.FindAll()
                       .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.ClubRegionId.Equals(regionId) });

                    model.ClubLocalities = region.Localities
                       .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name, Selected = model.ClubLocalityId.Equals(localityId) });

                    model.Clubs = locality.LocalitySportClubs
                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });

                    return View(model);
                }
                return RedirectToAction("Locality", new { model.Id });
            }
            return HttpNotFound("Не найден пользователь или населённый пункт");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SportClub(AddSportClubViewModel clubModel)
        {
            var user = userRepository.Get(clubModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.SportClub = clubRepository.Get(clubModel.ClubId);
            });

            return RedirectToAction("Info", new { clubModel.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public ActionResult LocalitiesDropDownList(long id, LocalitiesDropDownListViewModel localityModel)
        {
            localityModel.Localities = regionRepository.Get(id).Localities
                .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
            return PartialView(localityModel);
        }

        [HttpGet]
        public ActionResult ClubLocalitiesDropDownList(long id, LocalitiesDropDownListViewModel localityModel)
        {
            localityModel.Localities = regionRepository.Get(id).Localities
                .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
            return PartialView(localityModel);
        }

        [HttpGet]
        public ActionResult SportClubDropDownList(long id, long localityId, SportClubDropDownListViewModel clubModel)
        {
            var localities = regionRepository.Get(id).Localities;

            if (localityId == 0)
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

        [HttpGet]
        public ActionResult Email(long id)
        {
            var user = userRepository.Get(id);

            if (user != null)
            {
                return View(new EmailViewModel { Id = id, Email = user.Email });
            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email(EmailViewModel emailModel)
        {
            var user = userRepository.Get(emailModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.Email = emailModel.Email;
            });

            return RedirectToAction("Info", new { emailModel.Id });
        }

        [HttpGet]
        public ActionResult Phone(long id)
        {
            var user = userRepository.Get(id);

            if (user != null)
            {
                var model = new PhoneNumberViewModel { Id = id };

                model.PhoneNumber = user.PhoneNumber;

                return View(model);
            }

            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Phone(PhoneNumberViewModel numberModel)
        {
            var user = userRepository.Get(numberModel.Id);

            userRepository.InvokeInTransaction(() =>
            {
                user.PhoneNumber = numberModel.PhoneNumber;
            });

            return RedirectToAction("Info", new { numberModel.Id });
        }

        [HttpGet]
        public ActionResult ChangePassword(long id)
        {
            var user = userRepository.Load(id);
            if (user != null)
            {
                return View(new ChangePassViewModel { Id = id });
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassViewModel changeModel)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.Load(changeModel.Id);
                var changePass = UserManager.ChangePasswordAsync(user.Id, changeModel.Password, changeModel.NewPassword);
                if (changePass.Result.Succeeded)
                {
                    return RedirectToAction("Info", new { changeModel.Id });
                }

                ModelState.AddModelError("", "Произошла ошибка при смене пароля. Попробуйте ещё раз.");

                return View(changeModel);

            }

            return View(changeModel);
        }
    }
}