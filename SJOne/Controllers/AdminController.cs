using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using SJOne.Models;
using SJOne.Models.AdminViewModels;
using SJOne.Models.Filters;
using SJOne.Models.Repositories;


namespace SJOne.Controllers
{

    public class AdminController : BaseController
    {


        public AdminController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult UserList(UserFilter userFilter, FetchOptions options)
        {
            var users = userRepository.Find(userFilter, options);

            UserListViewModel userModel = new UserListViewModel();

            if (User.IsInRole("$Admin"))
            {
                userModel.Users = users;
            }
            else
            {
                userModel.Users = users.Where(u => u.UserName != "admin");
            }

            return View(userModel);
        }

        [HttpGet]
        public ActionResult Status(long id)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                return PartialView(new StatusViewModel { Status = Models.Status.Active });
            }
            return HttpNotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status(long id, StatusViewModel statusItem)
        {
            var user = userRepository.Get(id);
            if (user.UserName != "admin")
            {
                userRepository.InvokeInTransaction(() =>
                {
                    user.Status = statusItem.Status;
                });
            }
            return RedirectToAction("UserList", "Admin");
        }

        public ActionResult UserRoles(long id, UserRolesViewModel rolesModel)
        {
            var user = userRepository.Get(id);
            if (user != null)
            {
                rolesModel.Id = user.Id;
                rolesModel.UserName = user.UserName;
                rolesModel.Data = user.Name + " " + user.Surname;
                rolesModel.UserRoles = UserManager.GetRoles(user.Id);
                return View(rolesModel);
            }
            return RedirectToAction("UserList", "Admin");
        }

        [HttpGet]
        public ActionResult AddRoles(long id, SelectRolesViewModel model)
        {
            var user = UserManager.FindById(id);
            if (user != null)
            {
                model.Id = user.Id;
                var userRoles = UserManager.GetRoles(user.Id);
                var roles = RoleManager.Roles.Select(r => r.Name).Where(i => i != "$Admin");
                var listRoles = roles.Except(userRoles);
                model.RoleList = new MultiSelectList(listRoles, "RoleName");
                return PartialView(model);
            }
            return HttpNotFound("Пользователь не найден");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoles(SelectRolesViewModel model)
        {
            var user = UserManager.FindById(model.Id);
            UserManager.AddToRolesAsync(user.Id, model.RoleName);
            UserManager.UpdateAsync(user);
            return RedirectToAction("UserRoles", new { model.Id });


        }


        [HttpGet]
        public ActionResult DeleteRole(long id, string role)
        {
            var user = UserManager.FindById(id);
            if (role != "User")
            {
                UserManager.RemoveFromRole(user.Id, role);
                return RedirectToAction("UserRoles", "Admin", new { id });
            }
            return RedirectToAction("UserRoles", "Admin", new { id });
        }
    }
}