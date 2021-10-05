using ProtocolSim;
using SimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        BlSim.BlViewUser viewUser = new BlSim.BlViewUser();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Entry u, string retrunUrl)
        {
            
            try
            {
                if (viewUser.IsValid(u.Name,u.Password))
                {
                    FormsAuthentication.SetAuthCookie(u.Name, false);
                    if(viewUser.IsInRole(u.Name,"Admin"))
                       return RedirectToAction("Index", "Alldata");
                    if (viewUser.IsInRole(u.Name, "User"))
                        return RedirectToAction("Index", "ClinetHome", new { Area = "Clinet" });
                    else
                        return View("NoEntry");
                }
                else
                    return View("NoEntry");
            }
            catch
            {
                return View("NoEntry");
            }

        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
        //דף הבית של רשימת לקוחות
        public ActionResult EntryToUser()
        {
            return View();
        }
    }
}