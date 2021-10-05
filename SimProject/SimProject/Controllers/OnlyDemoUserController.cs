using BlSim;
using DalSim;
using ProtocolSim;
using SimProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class OnlyDemoUserController : Controller
    {
        private OnlyDemoUser onlyDemo = new OnlyDemoUser();

        // GET: OnlyDemoUser
        public ActionResult Index()
        {
            List<OnlyDemoUser> demoUsers = onlyDemo.GetDemoUsers();
            return View(demoUsers);
        }

        //קבל את כל רשימת הסימים שנמצאים ביחידה
        public ActionResult ListSim(string Filter)
        {
            List<Sim> sims = onlyDemo.GetOnlySimsUsers(Filter);
            ViewBag.counter = sims.Count;
            return View(sims);
        }

        //חפש לקוח/ יחידה מסויימת
        public ActionResult SearchUser(string Filter)
        {
            try
            {
                List<OnlyDemoUser> user = onlyDemo.ShrchUser(Filter);
                if (user.Count() == 0)
                    return View("NutFound");
                else
                    return View("Index", user);
            }
            catch
            {
                return View("NutFound");
            }
        }
    }
}
