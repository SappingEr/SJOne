using System;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;
using SJOne.Models;
using SJOne.Models.Repositories;

namespace SJOne.Controllers
{
    public class UserController : BaseController
    {
        public UserController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }


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
                infoModel.City = user.City;
                infoModel.Club = user.Club;
                infoModel.DOB = user.DOB;

                switch (user.Gender)
                {
                    case Gender.Male:
                        infoModel.Gender = "Мужской";
                        break;
                    case Gender.Female:
                        infoModel.Gender = "Женский";
                        break;
                    case Gender.No:
                        infoModel.Gender = null;
                        break;
                }
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
        public ActionResult EditUserInfo(long id)
        {
            var user = userRepository.Load(id);
            if (user != null)
            {
                return PartialView(new UserViewModel { Entity = user, UserLogin = user.UserName });
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditUserInfo(long id, UserViewModel userView)
        {
            userRepository.InvokeInTransaction(() =>
            {
                var user = userRepository.Load(id);
                user.UserName = userView.UserLogin;
                user.FIO = userView.Entity.FIO;
                user.Email = userView.Entity.Email;
            });
            return RedirectToAction("Info", new { id });
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
    }
}