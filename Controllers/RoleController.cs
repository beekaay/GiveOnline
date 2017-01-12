using GiveOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveOnline.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string rolename)
        {

            try
            {
                if (!string.IsNullOrEmpty(rolename))
                {


                    Microsoft.AspNet.Identity.EntityFramework.IdentityRole newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                    {
                        Name = rolename,

                    };

                    db.Roles.Add(newRole);
                    db.SaveChanges();

                    return RedirectToAction("index");
                }
            }

            catch (Exception)
            {
                return View();
            }

            return View();
        }


        [HttpPost]
        public ActionResult Delete(string Id)
        {
            var thisrole = db.Roles.FirstOrDefault(i => i.Id == Id);

            db.Roles.Remove(thisrole);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}