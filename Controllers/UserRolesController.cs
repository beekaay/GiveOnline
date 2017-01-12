using GiveOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GiveOnline.Controllers
{
    public class UserRolesController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> Usermanager { get; set; }


        public ActionResult Index()
        {
            var Userlist = db.Users.OrderBy(i => i.UserName).ToList().Select(i => new SelectListItem()
            {
                Text = i.UserName,
                Value = i.Id
            });
            ViewBag.Users = Userlist;
            var RoleList = db.Roles.OrderBy(i => i.Name).ToList().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Name
            });
            ViewBag.Roles = RoleList;


            return View();
        }

        [HttpPost]
        public ActionResult RoleAddToUser(string UserId, string Rolename)
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            userManager.AddToRole(UserId, Rolename);

            return RedirectToAction("Index");
        }
        public ActionResult GetRoles()
        {
            var Userlist = db.Users.OrderBy(i => i.UserName).ToList().Select(i => new SelectListItem()
            {
                Text = i.UserName,
                Value = i.UserName
            });
            ViewBag.Users = Userlist;

            return View();
        }

        [HttpPost]
        public ActionResult GetRoles(string Username)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                ApplicationUser user = db.Users.Where(m => m.UserName.Equals(Username)).FirstOrDefault();

                this.Usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
                ViewBag.RolesForThisUser = Usermanager.GetRoles(user.Id);
                var Userlist = db.Users.OrderBy(i => i.UserName).ToList().Select(i => new SelectListItem()
                {
                    Text = i.UserName,
                    Value = i.UserName
                });
                ViewBag.Users = Userlist;
            }

            return View();
        }
    }
}