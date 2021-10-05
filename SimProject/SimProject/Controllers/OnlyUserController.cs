using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlSim;
using ProtocolSim;

namespace SimProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class OnlyUserController : Controller
    {
        //BL גישה למחלקת 
        private BLOnlyUser bLOnlyUser = new BLOnlyUser();
         
        // GET: OnlyUser
        public ActionResult Index()
        {
            List<OnlyUser> users = bLOnlyUser.GetUsers();
            return View(users);
        }

        // GET: OnlyUser/Details/5
        public ActionResult Details(int id)
        {
            OnlyUser user = bLOnlyUser.GetOnlyUser(id);
            return View(user);
        }

        // GET: OnlyUser/Edit/5
        public ActionResult Edit(int id)
        {
            OnlyUser user = bLOnlyUser.GetOnlyUser(id);
            return View(user);
        }

        // POST: OnlyUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OnlyUser user)
        {
            try
            {
                // TODO: Add update logic here
                bLOnlyUser.UpDateUser(id, user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //חיפוש לקוח מסויים
        public ActionResult SearchUser(string Filter)
        {
            try
            {
                List<OnlyUser> user = bLOnlyUser.SearchUser(Filter);
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
