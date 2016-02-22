using Microsoft.AspNet.Identity;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Patients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PatientsController : Controller
    {
        private readonly IPatientService patients;

        public PatientsController(IPatientService patients)
        {
            this.patients = patients;
        }

        public ActionResult All()
        {

            return this.View();
        }

        [ChildActionOnly]
        public ActionResult PatientsPartial()
        {
            var doctorId = this.User.Identity.GetUserId();
            var patientsViewModel = this.patients.GetAllByDoctorId(doctorId).To<PatientViewModel>().ToList();
            return this.PartialView("_PatientsPartial", patientsViewModel);
        }

        public ActionResult AddDocuments(string id, HttpPostedFileBase document)
        {

            string directory = this.Server.MapPath(@"\Content\Documents\");

            if (document != null && document.ContentLength > 0)
            {
                var fileName = Guid.NewGuid() + "_" + id;
                document.SaveAs(Path.Combine(directory, fileName));
            }

            this.TempData["InfoMsg"] = "Successfully uploaded";
            return this.Redirect("/Doctor/Patients/All");
        }

    }
}