using Microsoft.AspNet.Identity;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Patient.Controllers
{
    [Authorize(Roles = "Patient")]
    public class ProfileController : Controller
    {
        private const string DocumentsPath = "~/App_Data/Uploads/patientDocuments";

        private readonly IDocumentsService documents;

        public ProfileController(IDocumentsService documents)
        {
            this.documents = documents;
        }

        // GET: Patient/Profile
        public ActionResult Index()
        {
            var patientId = this.User.Identity.GetUserId();
            var documentsViewModel = this.documents
                .GetDocumentsByPatientId(patientId)
                .To<DocumentViewModel>().ToList();
            return this.View(documentsViewModel);
        }

        [HttpGet]
        public FileResult DocumentDownload(int id)
        {
            var documentName = DocumentsPath + "/" + this.documents.GetDocumentNameById(id) + this.documents.GetDocumentExtensionById(id);


            string contentType = "application/" + this.documents.GetDocumentExtensionById(id).Substring(1);

            return new FilePathResult(documentName, contentType);

        }
    }
}