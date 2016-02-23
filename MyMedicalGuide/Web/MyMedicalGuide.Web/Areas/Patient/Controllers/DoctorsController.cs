using Microsoft.AspNet.Identity;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Controllers;
using MyMedicalGuide.Web.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Patient.Controllers
{
    [Authorize]
    public class DoctorsController : BaseController
    {
        private readonly IPatientRequestService patientRequest;

        public DoctorsController(IPatientRequestService patientRequest)
        {
            this.patientRequest = patientRequest;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PatientRequestInputModel request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(request);
            }
            else
            {
                var patientDb = this.Mapper.Map<PatientRequest>(request);
                patientDb.UserId = this.User.Identity.GetUserId();
                this.patientRequest.Add(patientDb);
                this.TempData["InfoMsg"] = "Successfully requested";
                return this.Redirect("/");
            }
        }
    }
}