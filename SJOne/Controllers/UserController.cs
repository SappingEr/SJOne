﻿using System;
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
        public ActionResult UserInfo(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                return View(new EditUserViewModel
                {
                                       
                    Name = user.Name,
                    Surname = user.Surname,
                    //City = user.City,
                    //Club = user.Club,
                    DOB = user.DOB
                });
            }
            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserInfo(long id, EditUserViewModel userModel)
        {
            userRepository.InvokeInTransaction(() =>
            {
                var user = userRepository.Get(id);
                          
                user.Name = userModel.Name;
                user.Surname = userModel.Surname;
                //user.City = userModel.City;
                //user.Club = userModel.Club;
                user.DOB = userModel.DOB;
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