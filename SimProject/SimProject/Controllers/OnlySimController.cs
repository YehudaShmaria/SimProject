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
    public class OnlySimController : Controller
    {
        //BL שימוש במחלקת 
        BLOnlySim bLOnlySim = new BLOnlySim();
        // GET: OnlySim
        public ActionResult Index()
        {
            List<OnlySim> onlySims = bLOnlySim.GetSims();
            return View(onlySims);
        }

        // GET: OnlySim/Details/5
        public ActionResult Details(int id)
        {
            OnlySim s = bLOnlySim.GetOnlySim(id);  
            return View(s);
        }
        // GET: OnlySim/Edit/5
        public ActionResult Edit(int id)
        {
            OnlySim sim = bLOnlySim.GetOnlySim(id);
            return View(sim);
        }

        // POST: OnlySim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OnlySim sim)
        {
            try
            {
                bLOnlySim.UpdateOnlySim(id, sim);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exist");
            }
        }

        //חיפוש סים מסויים
        public ActionResult SearchOnlySim(string Filter)
        {
            try
            {
                List<OnlySim> s = bLOnlySim.SearceSim(Filter);
                if (s.Count() == 0)
                    return View("NutFound");
                else
                return View("Index",s);
            }
            catch
            {
                return View("NotFound");
            }
            
        }
    }
}
