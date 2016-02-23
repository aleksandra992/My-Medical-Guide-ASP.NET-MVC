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
    public class PatientRequestService : IPatientRequestService
    {
        private readonly IRepository<PatientRequest, int> repo;

        public PatientRequestService(IRepository<PatientRequest, int> repo)
        {
            this.repo = repo;

        }

        public void Add(PatientRequest request)
        {
            this.repo.Add(request);
            this.repo.SaveChanges();
        }

        public void Delete(PatientRequest request)
        {
            this.repo.Delete(request);
            this.repo.SaveChanges();
        }

        public void Dispose()
        {
            this.repo.Dispose();
        }

        public IQueryable<PatientRequest> GetByDoctorId(string id)
        {
            return this.repo.All().Where(x => x.DoctorId == id);
        }

        public PatientRequest GetById(int id)
        {
            return this.repo.GetById(id);
        }

        public void Update(PatientRequest request)
        {
            this.repo.Update(request);
            this.repo.SaveChanges();
        }
    }
}
