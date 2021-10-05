using BlSim;
using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimProject.Areas.Clinet.Controllers
{
    [Authorize]
    public class DeviceClinetController : Controller
    {
        //BL שימוש במחלקת 
        private BlOnlyDeviceForUser forUser = new BlOnlyDeviceForUser();

        // GET: Clinet/ClinetDevice
        public ActionResult Index()
        {
            List<OnlyDevice> devices = forUser.GetDevices(User.Identity.Name);
            if (devices.Count() == 0)
            {
                return View("Empty");
            }
            return View("~/Areas/Clinet/Views/DeviceClinet/Index.cshtml", devices);
        }

        // GET: Clinet/ClinetDevice/Details/5
        public ActionResult Details(int id)
        {
            OnlyDevice device = forUser.GetOnlyDevice(id, User.Identity.Name);
            return View("~/Areas/Clinet/Views/DeviceClinet/Details.cshtml", device);
        }

        // GET: Clinet/ClinetDevice/Edit/5
        public ActionResult Edit(int id)
        {
            OnlyDevice device = forUser.GetOnlyDevice(id, User.Identity.Name);
            return View("~/Areas/Clinet/Views/DeviceClinet/Edit.cshtml", device);
        }

        // POST: Clinet/ClinetDevice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OnlyDevice device)
        {
            try
            {
                forUser.UpDateDevice(id, device);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //חיפוש מכשיר מסויים
        public ActionResult SearchDavice(string Filter)
        {

            try
            {
                List<OnlyDevice> devices = forUser.SearceOnlyDevice(User.Identity.Name, Filter);
                if (devices.Count() == 0)
                    return View("~/Areas/Clinet/Views/DeviceClinet/NuTFound.cshtml");
                else
                    return View("~/Areas/Clinet/Views/DeviceClinet/Index.cshtml", devices);
            }
            catch
            {
                return View("~/Areas/Clinet/Views/DeviceClinet/NuTFound.cshtml");
            }
        }
    }
}
