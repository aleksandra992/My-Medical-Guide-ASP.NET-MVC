using MyMedicalGuide.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IPatientRequestService
    {
        void Add(PatientRequest request);

        IQueryable<PatientRequest> GetByDoctorId(string id);

        void Update(PatientRequest request);

        void Delete(PatientRequest request);

        PatientRequest GetById(int id);

        void Dispose();
    }
}
