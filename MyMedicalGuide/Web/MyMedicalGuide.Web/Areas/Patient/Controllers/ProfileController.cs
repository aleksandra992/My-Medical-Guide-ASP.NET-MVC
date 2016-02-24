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

        private const int ItemsPerPage = 5;

        private readonly IDocumentsService documents;

        public ProfileController(IDocumentsService documents)
        {
            this.documents = documents;
        }

        // GET: Patient/Profile
        public ActionResult Index(int id = 1)
        {
            var patientId = this.User.Identity.GetUserId();

            var search = this.Request.QueryString["search"];
            var page = id;
            var allItemsCount = this.documents.GetDocumentsByPatientId(patientId)
                .Count();

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var skip = (page - 1) * ItemsPerPage;

            List<DocumentViewModel> documents;
            if (search != null)
            {
                documents = this.documents
                .GetDocumentsByPatientId(patientId)
                   .Where(x => x.RealFileName.Contains(search))
                   .To<DocumentViewModel>()
                   .ToList();
            }
            else
            {
                documents = this.documents
                .GetDocumentsByPatientId(patientId)
                   .OrderBy(x => x.CreatedOn)
                   .Skip(skip)
                   .Take(ItemsPerPage)
                   .To<DocumentViewModel>()
                   .ToList();
            }

            var resultModel = new PageableDocumentsViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Documents = documents
            };
            return this.View(resultModel);
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