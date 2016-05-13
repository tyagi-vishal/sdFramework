using System.Web.Mvc;

namespace Allevasoft.Areas.Rehab
{
    public class RehabAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Rehab";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Rehab_default",
                "Rehab/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}