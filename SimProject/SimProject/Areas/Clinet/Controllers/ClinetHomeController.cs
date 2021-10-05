using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimProject.Areas.Clinet.Controllers
{
    [Authorize]
    public class ClinetHomeController : Controller
    {
        // GET: Clinet/ClinetHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login","Home",new { Area=""});
        }
    }
}