using AgainArt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AgainArt.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(Email emailContact)
        {
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailContact.From);
            mailMessage.To.Add(ConfigurationManager.AppSettings["username"]);
            mailMessage.Subject = emailContact.Subject;
            mailMessage.Body = emailContact.Body;

            client.Send(mailMessage);

            return View("Index");

        }
    }
}