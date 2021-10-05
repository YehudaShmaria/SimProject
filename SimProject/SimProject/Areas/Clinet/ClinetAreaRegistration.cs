using System.Web.Mvc;

namespace SimProject.Areas.Clinet
{
    public class ClinetAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clinet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clinet_default",
                "Clinet/{controller}/{action}/{id}",
                new { Controller = "ClinetHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}