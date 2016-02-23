using MyMedicalGuide.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Data.Repositories;

namespace MyMedicalGuide.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IRepository<Document, int> documents;

        public DocumentsService(IRepository<Document, int> documents)
        {
            this.documents = documents;
        }

        public void Add(Document document)
        {
            this.documents.Add(document);
            this.documents.SaveChanges();
        }

        public string GetDocumentExtensionById(int id)
        {
            return this.documents.GetById(id).Extension;
        }

        public string GetDocumentNameById(int id)
        {
            return this.documents.GetById(id).FileName.ToString();
        }

        public IQueryable<Document> GetDocumentsByPatientId(string patientId)
        {
            return this.documents.All()
                .Where(x => x.PatientId == patientId);
        }
    }
}
