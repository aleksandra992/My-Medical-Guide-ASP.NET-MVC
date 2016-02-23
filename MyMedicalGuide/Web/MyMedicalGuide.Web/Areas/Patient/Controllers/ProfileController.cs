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

        //public FileResult Download(string FileID)
        //{
        //    int CurrentFileID = Convert.ToInt32(FileID);
        //    var filesCol = obj.GetFiles();
        //    string CurrentFileName = (from fls in filesCol
        //                              where fls.FileId == CurrentFileID
        //                              select fls.FilePath).First();

        //    string contentType = string.Empty;

        //    if (CurrentFileName.Contains(".pdf"))
        //    {
        //        contentType = "application/pdf";
        //    }

        //    else if (CurrentFileName.Contains(".docx"))
        //    {
        //        contentType = "application/docx";
        //    }
        //    return File(CurrentFileName, contentType, CurrentFileName);
        //}
    }
}