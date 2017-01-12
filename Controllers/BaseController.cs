using GiveOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveOnline.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public BaseController()
        {
            MetaDescription metadesc = db.MetaDescriptions.FirstOrDefault();
            MetaTag metatags = db.MetaTags.FirstOrDefault();

            ViewBag.MetaTags = metatags.Title;
            ViewBag.MetaDescription = metadesc.Title;
        }
    }
}