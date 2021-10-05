using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlSim;
using ProtocolSim;
using SimProject.Models;

namespace SimProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AllDataController : Controller
    {
        //BL שימוש במחלקת 
        private BLAllData allData = new BLAllData();

        // GET: AllData
        public ActionResult Index()
        {
            List<Sim> sims = allData.GetAllData();
            int i = sims.Count;
            ViewBag.Counter = i;
            return View(sims);
        }

        // GET: AllData/Details/5
        public ActionResult Details(int id)
        {
            BLAllData bLAllData = new BLAllData();
            Sim s = bLAllData.GetOneData(id);
            return View(s);
        }

        // GET: AllData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllData/Create
        [HttpPost]
        public ActionResult Create(Sim s)
        {
            try
            {
                allData.CreateAllData(s);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exist");
            }
        }

        // GET: AllData/Edit/5
        public ActionResult Edit(int id)
        {
            Sim s = allData.GetOneData(id);
            return View(s);
        }

        // POST: AllData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sim sim)
        {
            try
            {
                allData.UpdateAllData(id, sim);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exist");
            }
        }

        // GET: AllData/Delete/5
        public ActionResult Delete(int id)
        {
            Sim s = allData.GetOneData(id);
            return View(s);
        }

        // POST: AllData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Sim sim)
        {
            try
            {
  
                allData.DeleteAllData(id, sim);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //חפש סים מסויים
        public ActionResult SearchSim(string Filter)
        {
           
            try
            {
                List<Sim> s = allData.SearceSim(Filter);
                if(s.Count() == 0)
                    return View("NutFound");
                else
                return View("Index",s);
            }
            catch
            {
                return View("NutFound");
            }
        }  
    }
}
