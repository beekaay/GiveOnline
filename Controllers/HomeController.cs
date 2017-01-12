using GiveOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GiveOnline.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            HomeIndexViewModel vm = new HomeIndexViewModel
            {
                Carousels = db.Carousels.ToList(),
                Events = db.Events.ToList(),
                Abouts = db.Abouts.ToList(),
                MenuBoxs = db.MenuBoxs.ToList()
                
            };

            return View(vm);
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(GiveOnline.Models.Contact objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                foreach (var mailItem in db.NewsReceivers)
                {
                    string from = "givemeonlinez@gmail.com"; //gmail
                    using (MailMessage mail = new MailMessage(from, "givemeonlinez@gmail.com"))
                    {
                        mail.Subject = objModelMail.Subject;
                        mail.Body = objModelMail.Body;
                        if (fileUploader != null)
                        {
                            string fileName = Path.GetFileName(fileUploader.FileName);
                            mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                        }
                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "Test123Test"); //gmail password
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;
                        smtp.Send(mail);
                        ViewBag.Message = "Sent";

                    }
                }
                return View("Contact", objModelMail);

            }
            return RedirectToAction("Contact", "Home");
        }

        public ActionResult Browse(string category)
        {

            var categoryModel = db.Categories.Include("Products").Single(g => g.Title == category);

            return View(categoryModel);
        }

        public ActionResult SearchPage()
        {
            SearchViewModel vm = new SearchViewModel()
            {
                Events = new List<Event>(),
                Products = new List<Product>()
            };

            return View(vm);
        }


        [HttpPost]  
        public ActionResult SearchWord(string searchword)
        {
            SearchViewModel vm = new SearchViewModel()
            {
                Events = new List<Event>(),
                Products = new List<Product>()
            };

            if (!string.IsNullOrEmpty(searchword))
            {
                vm.Events = db.Events.Where(s => s.Title.Contains(searchword)).ToList();
                vm.Products = db.Products.Where(s => s.Title.Contains(searchword)).ToList();

            }

            if (vm.Events.Any())
            {
                ViewBag.Events = "Searchword found in Events:";
            }

            if (vm.Products.Any())
            {
                ViewBag.Products = "Searchword founs in Products:";
            }

            if (!vm.Events.Any() && !vm.Products.Any())
            {
                ViewBag.Error = "Searchword " + searchword + " dosen't exist.";
            }

            return View("SearchPage", vm);
        }


        public ActionResult About()
        {

            return View(db.Abouts.OrderBy(m => m.Id).ToList());
        }

        public ActionResult Story()
        {
            EventViewModel vm = new EventViewModel()
            {
                Events = db.Events.ToList(),
                Stories = db.Stories.ToList()
            };

            return View(vm);

        }

        public ActionResult Events()
        {
            EventViewModel vm = new EventViewModel()
            {
                Events = db.Events.OrderBy(m => m.StartDate).ToList(),
                Stories = db.Stories.ToList()
            };
            return View(vm);
        }

        public ActionResult GiveOnline()
        {

            return View(db.DonateOnlines.ToList());
        }

        public PartialViewResult _NextEvent()
        {
            return PartialView(db.Events.OrderBy(m => m.StartDate).ToList());
        }

        [HttpPost]
        public ActionResult NewsReceiver_Create(string email)
        {
            NewsReceiver newNewsReceiver = new NewsReceiver
            {
                Email = email
            };

            db.NewsReceivers.Add(newNewsReceiver);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public PartialViewResult _EventModal()
        {
            EventViewModel vm = new EventViewModel()
            {
                Events = db.Events.OrderBy(m => m.StartDate).ToList(),
                Stories = db.Stories.ToList()
            };           
            return PartialView(vm);
        }

        public PartialViewResult _DonateModal()
        {

            return PartialView(db.DonateOnlines.ToList());
        }

        public ActionResult Shop()
        {
            PostViewModel vm = new PostViewModel
            {
                Categories = db.Categories.ToList(),
                Products = db.Products.ToList(),
                Variants = db.Variants.ToList()
            };

            return View(vm);
        }

        public PartialViewResult _ShopNav()
        {
            return PartialView(db.Categories.ToList());
        }

        public PartialViewResult _Product()
        {

            PostViewModel vm = new PostViewModel
            {
                Categories = db.Categories.ToList(),
                Products = db.Products.ToList(),
                Variants = db.Variants.ToList()
            };

            return PartialView(vm);
        }
    }
    }