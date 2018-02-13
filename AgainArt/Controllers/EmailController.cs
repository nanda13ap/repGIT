﻿using AgainArt.Models;
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
    public class EmailController : BaseAlertController
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(Gallery gallery)
        {
            try

            {
                Email objEmailContact = gallery.Email;

                SmtpClient client = new SmtpClient();

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["username"], objEmailContact.Name);
                //new MailAddress(objEmailContact.From);
                mailMessage.To.Add(mailMessage.From.Address);
                mailMessage.Subject = "Message from your Website: Paintings";
                mailMessage.Body = string.Format("<h2>You have just received a message from your website.</h2><br><br> <b>Name:</b> {0}<br><b>Email:</b> {1}<br><b>Message: </b> {2} ", objEmailContact.Name, objEmailContact.From, objEmailContact.Body);
                mailMessage.Sender = new MailAddress(mailMessage.From.Address, objEmailContact.Name);
                mailMessage.IsBodyHtml = true;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

                client.Send(mailMessage);

                Success(string.Format("The information was successfully saved in the database."), true);
            }
            catch (Exception ex)
            {
                Danger("It looks like something went wrong. Please try again later.");
            }

            return RedirectToAction("Index", "Gallery");

        }
    }
}