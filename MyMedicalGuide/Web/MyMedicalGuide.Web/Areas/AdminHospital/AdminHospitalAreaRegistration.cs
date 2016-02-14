using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.AdminHospital
{
    public class AdminHospitalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminHospital";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminHospital_default",
                "AdminHospital/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}