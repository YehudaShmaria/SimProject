using SimProject.Areas.Clinet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimProject.Areas.Clinet.Controllers
{
    [Authorize]
    public class ContactClinetController : Controller
    {
        [HttpGet]
        public ActionResult SendGmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendGmail(Mail model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>שולח המייל: {0} ({1})</p><p>בקשה:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("yehudas1999@gmail.com"));  
                message.From = new MailAddress("yehudas1999@gmail.com");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "yehudas1999@gmail.com",  
                        Password = "207193780"  
                    };
                    smtp.Credentials = credential;
                    smtp.Host ="smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credential;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View("Sent");
        }

    }
}