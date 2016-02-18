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
    using Models.Doctors;
    using Data.Models;
    public class AppointmentsController : BaseController
    {
        private readonly IDoctorsService doctorsService;
        
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsController(IDoctorsService doctorsService, IAppointmentsService appointmentsService)
        {
            this.doctorsService = doctorsService;
            this.appointmentsService = appointmentsService;
        }

        [HttpGet]
        public ActionResult NewAppointment()
        {
            var inputAppointmentModel = new AppointmentInputModel();
            var doctors = doctorsService.GetAll();
            var outputDoctors = this.Mapper.Map<IEnumerable<DoctorBasicViewModel>>(doctors);

            inputAppointmentModel.Doctors = outputDoctors;

            return this.View(inputAppointmentModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentInputModel appointment)
        {
            if (this.ModelState.IsValid)
            {
                var appointmentDb = this.Mapper.Map<Appointment>(appointment);
                this.appointmentsService.Add(appointmentDb);
                this.TempData["AppointmentAddedMsg"] = "Succesfully appointment added";
                this.Redirect("/");
            }

            return View();

        }
    }
}