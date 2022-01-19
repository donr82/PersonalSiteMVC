using PersonalSiteMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {          
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                //send the cvm back to the form with the completed inputs
                return View(cvm);
            }
            //build the message
            string message = $"You have received an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br/>{cvm.Message}";
            //MailMessage - What sends the email
            MailMessage mm = new MailMessage("admin@don-richardson.com", "donr82@sbcglobal.net", cvm.Subject, message);

            //MailMessage properties
            //Allow HTML in the email
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            //Respond to the sender, and not our website
            mm.ReplyToList.Add(cvm.Email);

            //SmtpClient - This is the info from the host that allows this to be sent
            SmtpClient client = new SmtpClient("mail.don-richardson.com");

            //Client Credentials
            client.Credentials = new NetworkCredential("admin@don-richardson.com", "P@ssw0rd");

            //Try to send the email
            try
            {
                //attempt to send
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"We're sorry your request could not be completed at this time. Please try again later. Error Message:{ex.Message}<br/>{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}