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
    [Authorize]
    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService doctors;

        public DoctorsController(IDoctorsService doctors)
        {
            this.doctors = doctors;
        }

        [ChildActionOnly]
        public ActionResult GetDoctors(int hospitalId, int departmentId)
        {
            var doctors = this.doctors.GetAllDoctorsFromDepartmentHospital(hospitalId, departmentId)
                 .To<DoctorTableViewModel>();

            return this.PartialView("_DoctorsPartial", doctors);
        }

    }
}