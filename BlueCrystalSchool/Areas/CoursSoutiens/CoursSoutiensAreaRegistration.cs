using System.Web.Mvc;

namespace BlueCrystalSchool.Areas.CoursSoutiens
{
    public class CoursSoutiensAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CoursSoutiens";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CoursSoutiens_default",
                "CoursSoutiens/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}