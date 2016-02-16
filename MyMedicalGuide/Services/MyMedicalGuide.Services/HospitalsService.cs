namespace MyMedicalGuide.Services
{
    using MyMedicalGuide.Services.Contracts;
    using System.Linq;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Data.Repositories;

    public class HospitalsService : IHospitalsService
    {
        private readonly IRepository<Hospital, int> hospitals;

        public HospitalsService(IRepository<Hospital, int> hospitals)
        {
            this.hospitals = hospitals;
        }

        public IQueryable<Hospital> GetAll()
        {
            return this.hospitals.All();
        }

        public Hospital GetById(int id)
        {
            return this.hospitals.GetById(id);
        }
    }
}
