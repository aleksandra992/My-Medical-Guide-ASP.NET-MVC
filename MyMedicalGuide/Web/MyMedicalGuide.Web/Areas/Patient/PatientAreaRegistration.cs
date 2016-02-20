using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Patient
{
    public class PatientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Patient";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Patient_default",
                "Patient/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                   namespaces: new[] { "MyMedicalGuide.Web.Areas.Patient.Controllers" });
        }
    }
}