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
    public class MailSenderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult News_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult News_Create(GiveOnline.Models.NewsLetter objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                foreach (var mailItem in db.NewsReceivers)
                {
                    string from = "givemeonlinez@gmail.com"; //gmail
                    using (MailMessage mail = new MailMessage(from, mailItem.Email))
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
                return View("News_Create", objModelMail);

            }
            return RedirectToAction("Index", "Admin");
        }
    }
}