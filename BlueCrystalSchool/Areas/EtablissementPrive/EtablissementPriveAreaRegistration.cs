using System.Web.Mvc;

namespace BlueCrystalSchool.Areas.EtablissementPrive
{
    public class EtablissementPriveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EtablissementPrive";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EtablissementPrive_default",
                "EtablissementPrive/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}