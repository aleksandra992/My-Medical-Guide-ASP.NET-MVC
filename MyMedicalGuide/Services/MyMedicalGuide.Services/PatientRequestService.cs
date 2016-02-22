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
    }
}
