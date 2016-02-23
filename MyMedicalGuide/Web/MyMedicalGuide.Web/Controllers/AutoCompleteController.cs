using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Controllers
{
    public class AutoCompleteController : BaseController
    {
        private readonly IDoctorsService doctors;

        public AutoCompleteController(IDoctorsService doctors)
        {
            this.doctors = doctors;
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult AutoCompleteDoctors(string term)
        {
            var entity = this.doctors.GetDoctors(term);

            var result = entity.To<DoctorBasicViewModel>().ToList();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
