using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtocolSim;
using BlSim;

namespace SimProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class OnlyDeviceController : Controller
    {
        //BL שימוש במחלקת 
        private BLOnlyDevice bLOnlyDevice = new BLOnlyDevice();

        // GET: OnlyDevice
        public ActionResult Index()
        {
            List<OnlyDevice> devices = bLOnlyDevice.GetDevices();
            return View(devices);
        }

        // GET: OnlyDevice/Details/5
        public ActionResult Details(int id)
        {
            OnlyDevice device = bLOnlyDevice.GetOnlyDevice(id);
            return View(device);
        }

        // GET: OnlyDevice/Edit/5
        public ActionResult Edit(int id)
        {
            OnlyDevice device =  bLOnlyDevice.GetOnlyDevice(id);
            return View(device);
        }

        // POST: OnlyDevice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OnlyDevice device)
        {
            try
            {
                bLOnlyDevice.UpDateDevice(id, device);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Exist");
            }
        }

        //חיפוש מכשיר מסויים
        public ActionResult SearchDavice(string Filter)
        {

            try
            {
                List<OnlyDevice> devices = bLOnlyDevice.SearchDevice(Filter);
                if (devices.Count() == 0)
                    return View("NutFound");
                else
                    return View("Index", devices);
            }
            catch
            {
                return View("NuTFound");
            }
        }
    }
}
