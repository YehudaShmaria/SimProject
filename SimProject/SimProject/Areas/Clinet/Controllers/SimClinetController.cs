using BlSim;
using ProtocolSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace SimProject.Areas.Clinet.Controllers
{
    [Authorize]
    public class SimClinetController : Controller
    {
        //BL שימוש במחלקת 
        BLOnlySimForUser forUser = new BLOnlySimForUser();
        
        // GET: Clinet/ClinetSim
        public ActionResult Index()
        {
            List<OnlySim> onlySims = forUser.GetSims(User.Identity.Name);
            if (onlySims.Count() == 0)
            {
                return View("Empty");
            }
            else
                return View("~/Areas/Clinet/Views/SimClinet/Index.cshtml", onlySims);
        }

        // GET: Clinet/ClinetSim/Details/5
        public ActionResult Details(int id)
        {
            OnlySim s = forUser.GetOnlySim(id,User.Identity.Name);
            return View("~/Areas/Clinet/Views/SimClinet/Details.cshtml", s);
        }

        //חיפוש סים מסויים
        public ActionResult SearchOnlySim(string Filter)
        {
            try
            {
                List<OnlySim> s = forUser.SearceSim(User.Identity.Name,Filter);
                if (s.Count() == 0)
                    return View("~/Areas/Clinet/Views/SimClinet/NutFound.cshtml");
                else
                    return View(@"~/Areas/Clinet/Views/SimClinet/Index.cshtml",s);
            }
            catch
            {
                return View("~/Areas/Clinet/Views/SimClinet/NutFound.cshtml");
            }

        }
    }
}
