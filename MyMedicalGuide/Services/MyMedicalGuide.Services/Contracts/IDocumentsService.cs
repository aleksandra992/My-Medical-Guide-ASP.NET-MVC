using MyMedicalGuide.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IDocumentsService
    {
        void Add(Document document);

        IQueryable<Document> GetDocumentsByPatientId(string patientId);

        string GetDocumentNameById(int id);

        string GetDocumentExtensionById(int id);

    }
}
