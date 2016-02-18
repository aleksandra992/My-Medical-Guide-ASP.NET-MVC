using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMedicalGuide.Web.Areas.Patient.Controllers
{
    using System.Web.Mvc;

    using MyMedicalGuide.Web.Controllers;
    using MyMedicalGuide.Web.Models.Appointments;
    using Services.Contracts;
    public class AppointmentsController : BaseController
    {
        private readonly IDoctorsService doctorsService;

        public AppointmentsController(IDoctorsService doctorsService)
        {
            this.doctorsService = doctorsService;
        }

    [HttpGet]
    public ActionResult NewAppointment()
    {
        var inputAppointmentModel = new AppointmentInputModel();
        var doctors = new List<string> { "aaa", "bbb" };
        inputAppointmentModel.Doctors = doctors;

        return this.View(inputAppointmentModel);
    }

    [HttpPost]
    [Authorize]
    public ActionResult Create(AppointmentInputModel appointment)
    {
        return null;
    }
}
}