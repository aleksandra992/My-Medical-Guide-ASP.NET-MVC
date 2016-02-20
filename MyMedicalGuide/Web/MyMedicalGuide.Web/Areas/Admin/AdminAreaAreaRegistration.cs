using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                   namespaces: new[] { "MyMedicalGuide.Web.Areas.Admin.Controllers" }
                   );
        }
    }
}