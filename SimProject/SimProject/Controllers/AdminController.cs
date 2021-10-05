using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimProject.Controllers
{
 
    [Authorize(Roles = ("Admin"))]
    public class AdminController : Controller
    {
        //שימוש במחלקת BL
        private BlSim.BlViewUser viewUser = new BlSim.BlViewUser();

        //שליחת כל המשתמשים באתר
        public ActionResult Index()
        {
            List<Login> logins = viewUser.GetLogins();
            return View(logins);
        }

        //שליחת פרטי משתמש ספציפי
        public ActionResult Details(int id)
        {
            Login login = viewUser.GetLogin(id); 
            return View(login);
        }

        //תצוגת יצירת משתמש
        public ActionResult Create()
        {
            return View();
        }

        //שליחת נתוני משתמש חדש
        [HttpPost]
        public ActionResult Create(Login login)
        {
            try
            {
                viewUser.CreateLogin(login);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exsite");
            }
           
        }

        //תצוגת עריכת משתמש
        public ActionResult Edit(int id)
        {
            Login login = viewUser.GetLogin(id);
            return View(login);
        }

        //שליחת נתוני עריכת משתמש
        [HttpPost]
        public ActionResult Edit(int id, Login login)
        {
            try
            {
                viewUser.UpdateLogin(id, login);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       //תצוגת מחיקת משתמש
        public ActionResult Delete(int id)
        {
            Login login = viewUser.GetLogin(id);
            return View(login);
        }

       //עדכון מחיקת משתמש
        [HttpPost]
        public ActionResult Delete(int id,  Login login)
        {
            try
            {
                viewUser.DeleteLogin(id, login);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //תצוגת חיפוש משתמש מסויים
        public ActionResult SharchLogin(string Filter)
        {
            try
            {
                List<Login> logins = viewUser.SharchLogin(Filter);
                if(logins.Count==0)
                {
                    return View("NotFound");
                }
                else
                return View("Index", logins);
            }
            catch
            {
                return View("NotFound");
            }
        }
    }
}
