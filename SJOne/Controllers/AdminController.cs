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

        // GET: Admin
        public ActionResult UserList(UserListViewModel userModel, UserFilter userFilter, FetchOptions options)
        {
            userModel.Users = userRepository.Find(userFilter, options);
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
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult UserRoles(long id, UserRolesViewModel userRolesMod)
        {
            var user = UserManager.FindById(id);
            if (user != null)
            {
                userRolesMod.Id = user.Id;
                userRolesMod.UserName = user.UserName;
                userRolesMod.UserRoles = UserManager.GetRoles(user.Id);
                return View(userRolesMod);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult AddRoles(long id, SelectRolesViewModel model)
        {
            var user = UserManager.FindById(id);
            if (user != null)
            {
                model.Id = user.Id;
                var userRoles = UserManager.GetRoles(user.Id);
                var roles = RoleManager.Roles.Select(r => r.Name).ToList();
                var listRoles = roles.Except(userRoles).ToList();
                model.RoleList = new MultiSelectList(listRoles, "RoleName");
                return PartialView(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult AddRoles(SelectRolesViewModel model)
        {
            var user = UserManager.FindById(model.Id);
            if (user != null)
            {
                UserManager.AddToRolesAsync(user.Id, model.RoleName);
                UserManager.UpdateAsync(user);
                return RedirectToAction("UserRoles", new { model.Id });
            }
            return RedirectToAction("UserRoles", "Admin", new { model.Id });
        }

        public ActionResult DeleteRole(long id, string role)
        {
            var user = UserManager.FindById(id);
            if (role != "Guest")
            {
                UserManager.RemoveFromRole(user.Id, role);
                return RedirectToAction("UserRoles", "Admin", new { id });
            }
            return RedirectToAction("UserRoles", "Admin", new { id });




        }
    }
}