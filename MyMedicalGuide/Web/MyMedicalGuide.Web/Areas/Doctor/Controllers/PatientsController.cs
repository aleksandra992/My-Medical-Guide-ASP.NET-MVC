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
        private const int ItemsPerPage = 5;

        private readonly IPatientService patients;

        private readonly IDocumentsService documents;


        public PatientsController(IPatientService patients, IDocumentsService documents)
        {
            this.patients = patients;
            this.documents = documents;
        }

        public ActionResult All(int id = 1)
        {
            var doctorId = this.User.Identity.GetUserId();

            var search = this.Request.QueryString["search"];
            var page = id;
            var allItemsCount = this.patients.GetAllByDoctorId(doctorId)
                .Count();

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var skip = (page - 1) * ItemsPerPage;

            //this.patients.GetAllByDoctorId(doctorId).To<PatientViewModel>().ToList();

            List<PatientViewModel> patients;
            if (search != null)
            {

                patients = this.patients
                  .GetAllByDoctorId(doctorId)
                   .Where(x => x.SSN.Contains(search))
                   .To<PatientViewModel>()
                   .ToList();
            }
            else
            {
                patients = this.patients
                   .GetAllByDoctorId(doctorId)
                   .OrderBy(x => x.Id)
                   .Skip(skip)
                   .Take(ItemsPerPage)
                   .To<PatientViewModel>()
                   .ToList();
            }

            var resultModel = new PagingPatientViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Patients = patients
            };


            return this.View(resultModel);
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