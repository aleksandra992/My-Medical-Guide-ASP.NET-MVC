using Microsoft.AspNet.Identity;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Documents;
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
        private const string RequestsPath = "~/App_Data/Uploads/";

        private readonly IPatientService patients;

        private readonly IDocumentsService documents;

        public PatientsController(IPatientService patients, IDocumentsService documents)
        {
            this.patients = patients;
            this.documents = documents;
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

        [ValidateAntiForgeryToken]
        public ActionResult AddDocuments(string id, HttpPostedFileBase document, string doctorFileName)
        {
            string doctorId = this.User.Identity.GetUserId();

            var documentDb = new Document()
            {
                DoctorId = doctorId,
                PatientId = id,
                RealFileName = doctorFileName,
                Extension = Path.GetExtension(document.FileName)
            };

            this.documents.Add(documentDb);

            var fileName = documentDb.FileName;
            var documentId = documentDb.Id;


            var folder = "patientDocuments";
            var realFileName = fileName.ToString();

            var path = Path.Combine(this.Server.MapPath(RequestsPath + folder), realFileName + Path.GetExtension(document.FileName));
            document.SaveAs(path);


            this.TempData["InfoMsg"] = "Successfully uploaded";
            return this.Redirect("/Doctor/Patients/All");
        }

    }
}